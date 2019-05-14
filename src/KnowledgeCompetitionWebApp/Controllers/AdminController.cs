using KnowledgeCompetitionWebApp.Helpers;
using KnowledgeCompetitionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class AdminController : Controller
    {
        public Context dbContext { get; set; }

        public AdminController()
        {
            dbContext = new Context();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Student", "Admin");
        }
        public ActionResult Student()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    var model = dbContext.Users.Where(u => u.UserType == 2).ToList();
                    return View(model);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult NewStudent()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {

                    return View();
                }
                return RedirectToAction("Index", "Login");

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Teacher()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    var model = dbContext.Users.Where(u => u.UserType == 1).ToList();
                    return View(model);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewTeacher()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {

                    return View();
                }
                return RedirectToAction("Index", "Login");

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Admin()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    var model = dbContext.Users.Where(u => u.UserType == 0).ToList();
                    return View(model);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewAdmin()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {

                    return View();
                }
                return RedirectToAction("Index", "Login");

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Category()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    var model = dbContext.Categories.ToList();
                    return View(model);
                }
                return RedirectToAction("Index", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewCategory()
        {
            //var model = dbContext.Categories.ToList();
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {

                    return View();
                }
                return RedirectToAction("Index", "Login");

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Question()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    if (dbContext.Categories.Where(c => c.IsActive == true).Any() && dbContext.Questions.Any())
                    {
                        var categories = dbContext.Categories.Where(c => c.IsActive == true).ToList();
                        var questions = dbContext.Questions.ToList();
                        var correctAnswers = dbContext.CorrectAnswers.ToList();
                        var model = new CategoryQuestion
                        {
                            Categories = categories,
                            Questions = questions,
                            CorrectOptions = correctAnswers
                        };
                        return View(model);
                    }

                    return View();
                }

                return RedirectToAction("Index", "Login");
            }
            catch 
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewQuestion()
        {   
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    var model = dbContext.Categories.Where(c => c.IsActive == true).ToList();
                    return View(model);
                }
                return RedirectToAction("Index", "Login");

            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Results(int studentId = -1)
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 0)
                {
                    if (studentId <= 0)
                        throw new Exception();
                    List<Models.ResultsToDisplay> results = new List<Models.ResultsToDisplay>();
                    var competitions = dbContext.Competitions.Where(o => o.UserId == studentId).ToList();
                    foreach (var competition in competitions)
                    {
                        competition.Questions = dbContext.Questions.Where(q => q.Competitions.Any(c => c.Id == competition.Id)).ToList();
                        var categoryId = 0;
                        if (competition.Questions.FirstOrDefault() != null && competition.Questions.Count > 0)
                        {
                            categoryId = competition.Questions.FirstOrDefault().CategoryId;
                        }

                        results.Add(
                            new Models.ResultsToDisplay
                            {
                                CompetitionId = competition.Id,
                                QuestionsCount = competition.Questions.Count(),
                                AnsweredCount = dbContext.Results.Where(r => r.CompetitionId == competition.Id).Count(),
                                CategoryName = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId).Name,
                                CompetitionDate = competition.CreatedDate
                            }
                        );
                    }

                    return View("Results", results.OrderByDescending(r => r.CompetitionDate));

                }

                    return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}