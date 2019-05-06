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
        
        public ActionResult Student()
        {
            var model = dbContext.Users.Where(u => u.UserType == 2).ToList();
            return View(model);
        }
        public ActionResult NewStudent()
        {
            return View();
        }

        public ActionResult Teacher()
        {
            var model = dbContext.Users.Where(u => u.UserType == 1).ToList();
            return View(model);
        }

        public ActionResult NewTeacher()
        {
            return View();
        }

        public ActionResult Admin()
        {
            var model = dbContext.Users.Where(u => u.UserType == 0).ToList();
            return View(model);
        }

        public ActionResult NewAdmin()
        {
            return View();
        }

        public ActionResult Category()
        {
            var model = dbContext.Categories.ToList();
            return View(model);
        }

        public ActionResult NewCategory()
        {
            //var model = dbContext.Categories.ToList();
            return View();
        }

        public ActionResult Question()
        {
            if(dbContext.Categories.Where(c => c.IsActive == true).Any() && dbContext.Questions.Any()){
                var categories = dbContext.Categories.Where(c => c.IsActive == true).ToList();
                var questions = dbContext.Questions.ToList();
                var correctAnswers = dbContext.CorrectAnswers.ToList();
                var model = new CategoryQuestion{
                    Categories = categories,
                    Questions = questions,
                    CorrectOptions = correctAnswers
                };
                return View(model);
            }

            return View();
        }

        public ActionResult NewQuestion()
        {
            var model = dbContext.Categories.Where(c => c.IsActive == true).ToList();
            return View(model);
        }
        
    }
}