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
    }
}