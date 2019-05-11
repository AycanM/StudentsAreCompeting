﻿using KnowledgeCompetitionWebApp.Helpers;
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

    }
}