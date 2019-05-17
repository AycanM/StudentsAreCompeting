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

        public ActionResult Competition(string competition = "")
        {
            try
            {
                if (Session["userType"] == null || Convert.ToInt16(Session["userType"]) != 2)
                    throw new Exception();
                if ((competition == "" || string.IsNullOrEmpty(competition)) && Request.QueryString["competition"] == null)
                    return RedirectToAction("AvailableCompetition", "Student");

                competition = !string.IsNullOrEmpty(competition) ? competition : Request.QueryString["competition"].ToString();

                var competitionModel = dbContext.Competitions.Where(o => o.CompetitionCode == competition).FirstOrDefault();
                competitionModel.Questions = dbContext.Questions.Where(q => q.Competitions.Any(c => c.Id == competitionModel.Id)).ToList();

                return View("Competition", competitionModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Results(int ResultId = -1)
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 2)
                {
                    int userId = Convert.ToInt16(Session["userId"]);

                    if (ResultId != -1)
                    {
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
                            Questions = dbContext.Questions.Where(q => q.Competitions.Any(c => c.Id == ResultId)).ToList(),
                            Results = dbContext.Results.Where(r => r.CompetitionId == ResultId).ToList(),
                            CorrectAnswers = correctAnswers,
                            CategoryName = dbContext.Categories.Where(c => c.Id == catId).FirstOrDefault().Name
                        };

                        return View("CompetitionDetail", competitionDetail);
                    }

                    List<Models.ResultsToDisplay> results = new List<Models.ResultsToDisplay>();
                    var competitions = dbContext.Competitions.Where(o => o.UserId == userId).ToList();
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

        public ActionResult UserProfile()
        {
            if (Session["userType"] == null && Convert.ToInt16(Session["userType"]) == 0)
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}