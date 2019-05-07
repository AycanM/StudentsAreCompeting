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

    }
}