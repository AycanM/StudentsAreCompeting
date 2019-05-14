using KnowledgeCompetitionWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class StudentController : Controller
    {
        public Context dbContext { get; set; }

        public StudentController()
        {
            dbContext = new Context();
        }
        public ActionResult Index()
        {
            return RedirectToAction("AvailableCompetition", "Student");
        }

        public ActionResult Competition(string competition="")
        {
            try
            {
                if (Session["userType"] == null || Convert.ToInt16(Session["userType"]) != 2)
                    throw new Exception();
                if ((competition == "" || string.IsNullOrEmpty(competition)) && Request.QueryString["competition"] == null)
                    return RedirectToAction("AvailableCompetition", "Student");

                competition = !string.IsNullOrEmpty(competition) ? competition : Request.QueryString["competition"].ToString();

                var competitionModel = dbContext.Competitions.Where(o => o.CompetitionCode == competition).FirstOrDefault();
                competitionModel.Questions = dbContext.Questions.Select(q => q).Where(q => q.Competitions.FirstOrDefault().Id == competitionModel.Id).ToList();

                return View("Competition", competitionModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Results()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 2)
                {
                    List<Models.ResultsToDisplay> results = new List<Models.ResultsToDisplay>();
                    int userId = Convert.ToInt16(Session["userId"]);
                    var competitions = dbContext.Competitions.Where(o => o.UserId == userId).ToList();
                    foreach (var competition in competitions)
                    {
                        int CompetitionId = competition.Id;
                        competition.Questions = dbContext.Questions.Where(q => q.Competitions.FirstOrDefault().Id == competition.Id).ToList();
                        int QuestionCount = dbContext.Questions.Where(q => q.Competitions.FirstOrDefault().Id == competition.Id).Count(); //10
                        int AnsweredCount = dbContext.Results.Where(r => r.CompetitionId == competition.Id).Count();
                        var categoryId = competition.Questions.FirstOrDefault().CategoryId;

                        string CategoryName = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId).Name;
                        string CompetitionDate = competition.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");

                        results.Add(
                            new Models.ResultsToDisplay {
                                CompetitionId   = competition.Id,
                                QuestionsCount  = competition.Questions.Count(),
                                AnsweredCount   = dbContext.Results.Where(r => r.CompetitionId == competition.Id).Count(),
                                CategoryName    = dbContext.Categories.FirstOrDefault(c => c.Id == categoryId).Name,
                                CompetitionDate = competition.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss")
                            }
                        );

                        
                    }

                    return View("Results", results);
                }
                return RedirectToAction("Index", "Login");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult AvailableCompetition()
        {

            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 2)
                {
                    List<Models.Category> model = new List<Models.Category>();
                    List<Models.Question> questions;
                    foreach (Models.Category category in dbContext.Categories.Where(c => c.IsActive))
                    {
                        questions = dbContext.Questions.Where(q => q.CategoryId == category.Id).ToList();
                        if (questions.Any(q => q.Level == 1) &&
                            questions.Any(q => q.Level == 2) &&
                            questions.Any(q => q.Level == 3) &&
                            questions.Any(q => q.Level == 4) &&
                            questions.Any(q => q.Level == 5) &&
                            questions.Any(q => q.Level == 6) &&
                            questions.Any(q => q.Level == 7) &&
                            questions.Any(q => q.Level == 8) &&
                            questions.Any(q => q.Level == 9) &&
                            questions.Any(q => q.Level == 10)
                           )
                        {
                            model.Add(category);
                        }

                    }
                    return View(model);
                }
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}