using KnowledgeCompetitionWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class LoginController : Controller
    {

        public Context dbContext { get; set; }

        public LoginController()
        {
            dbContext = new Context();
        }

        // GET: Login
        public ActionResult Index()
        {
            if (Session["userType"] != null)
            {
                int userType = Convert.ToInt16(Session["userType"]);
                switch (userType)
                {
                    case 0:
                        return RedirectToAction("Student", "Admin");
                    case 1:
                        return RedirectToAction("Student", "Teacher");
                    case 2:
                        return RedirectToAction("AvailableCompetition", "Student");
                }
            }
            return View();
        }

        public JsonResult Login(string email, string password)
        {
            try
            {

                if (!dbContext.Users.Any(u => u.Email.ToLower() == email.ToLower().Trim()))
                    return Json(new { status = 0 });
                if (dbContext.Users.Any(u => u.Email.ToLower() == email.ToLower().Trim() && u.Password != password))
                    return Json(new { status = 2 });
                var user = dbContext.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                Session["userId"] = user.Id;
                Session["userType"] = user.UserType;
                Session["userEmail"] = user.Email;
                Session["userName"] = user.Name;
                Session["userSurname"] = user.Surname;
                return Json(
                    new
                    {
                        status = 1,
                        type = user.UserType
                    }
                );
            }
            catch (Exception ex)
            {
                return Json(
                    new
                    {
                        status = 0
                    }
                );
            }
        }

        public ActionResult SignOut()
        {
            Session.Remove("userId");
            Session.Remove("userType");
            Session.Remove("userEmail");
            Session.Remove("userName");
            Session.Remove("userSurname");
            return RedirectToAction("Index", "Login");
        }
    }
}