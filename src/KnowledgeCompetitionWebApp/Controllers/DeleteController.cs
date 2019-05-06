using KnowledgeCompetitionWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class DeleteController : Controller
    {
        public Context dbContext { get; set; }
        public DeleteController()
        {
            dbContext = new Context();
        }


        public JsonResult User(int id)
        {
            try
            {
                var user = dbContext.Users.Where(s => s.Id == id).FirstOrDefault();
                if(user == null)
                    throw new Exception();

                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                return Json(new { status = 1 });
                
            }
            catch (Exception ex)
            {
                return Json(new { status = 0 });
            }
        }

        public JsonResult Category(int id)
        {
            try
            {
                var category = dbContext.Categories.Where(s => s.Id == id).FirstOrDefault();
                if (category == null)
                    throw new Exception();

                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
                return Json(new { status = 1 });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0 });
            }
        }

        public JsonResult Question(int id)
        {
            try
            {
                var question = dbContext.Questions.Where(q => q.Id == id).FirstOrDefault();
                if (question == null)
                    throw new Exception();
                dbContext.Questions.Remove(question);
                dbContext.SaveChanges();
                return Json(new { status = 1 });
            }
            catch (Exception)
            {

                return Json(new { status = 0 });
            }
        }
    }
}