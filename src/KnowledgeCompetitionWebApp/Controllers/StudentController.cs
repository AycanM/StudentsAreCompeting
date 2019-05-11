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
        public ActionResult Competition(int category = 0)
        {
            if (category == 0 || Request.QueryString["category"] == null)
                return RedirectToAction("AvailableCompetition", "Student");
            return View();
        }

        public ActionResult Results()
        {
            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 2)
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

        public ActionResult AvailableCompetition()
        {

            try
            {
                if (Session["userType"] != null && Convert.ToInt16(Session["userType"]) == 2)
                {
                    List<Models.Category> model = new List<Models.Category>();
                    List<Models.Question> questions;
                    foreach (Models.Category category in dbContext.Categories)
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