using KnowledgeCompetitionWebApp.Helpers;
using KnowledgeCompetitionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class TeacherController : Controller
    {
        static int userId { get; set; }
        public Context dbContext { get; set; }
        // GET: Teacher
        public TeacherController()
        {
            dbContext = new Context();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Student", "Teacher");
        }
        public ActionResult Student()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
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
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
                {
                    if (studentId <= 0)
                        throw new Exception();

                    userId = studentId;
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

        public ActionResult CompetitionDetail(int ResultId = -1)
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 1)
                {
                    if (ResultId <= 0)
                        throw new Exception();
                    var questions = dbContext.Questions.Where(q => q.Competitions.Any(c => c.Id == ResultId)).ToList();
                    var catId = questions.FirstOrDefault().CategoryId;
                    var correctAnswers = new List<Models.CorrectAnswer>();
                    foreach (var question in questions)
                    {
                        var correctAnswer = dbContext.CorrectAnswers.Where(a => a.QuestionId == question.Id).FirstOrDefault();
                        correctAnswers.Add(correctAnswer);
                    }
                    Models.CompetitionDetail competitionDetail = new Models.CompetitionDetail
                    {
                        User = dbContext.Users.Where(u => u.Id == userId).FirstOrDefault(),
                        Competition = dbContext.Competitions.Where(c => c.Id == ResultId).FirstOrDefault(),
                        Questions = questions, //dbContext.Questions.Where(q => q.Competitions.Any(c => c.Id == ResultId)).ToList(),
                        Results = dbContext.Results.Where(r => r.CompetitionId == ResultId).ToList(),
                        CorrectAnswers = correctAnswers,
                        CategoryName = dbContext.Categories.Where(c => c.Id == catId).FirstOrDefault().Name
                    };

                    return View("CompetitionDetail", competitionDetail);
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult UserProfile()
        {
            if (Session["userType"] == null && Convert.ToInt16(Session["userType"]) == 0)
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}