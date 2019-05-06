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
        public ActionResult Competition(int category = 0)
        {
            if (category == 0 || Request.QueryString["category"] == null)
                return RedirectToAction("AvailableCompetition", "Student");
            return View();
        }

        public ActionResult Results()
        {
            return View();
        }

        public ActionResult AvailableCompetition()
        {
            
            var model = dbContext.Categories.Where(c => c.IsActive == true).ToList();
            return View(model);
        }
    }
}