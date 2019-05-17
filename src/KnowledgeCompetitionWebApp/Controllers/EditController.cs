using KnowledgeCompetitionWebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class EditController : Controller
    {
        public Context dbContext { get; set; }
        public EditController()
        {
            dbContext = new Context();
        }
        public JsonResult GetUser(int id)
        {

            var user = dbContext.Users.Where(u => u.Id == id).FirstOrDefault();

            return Json(new {
                id = user.Id,
                name = user.Name,
                surname = user.Surname,
                email = user.Email
            });
        }

        public JsonResult User(string name, string surname, string email, int id)
       
 {
            try
            {
                if (dbContext.Users.Where(u => u.Id != id).Any(u => u.Email.Trim() == email.Trim()))
                    return Json(new { status = 2 });
                var user = dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                dbContext.SaveChanges();

                return Json(new
                {
                    id = user.Id,
                    name = user.Name,
                    surname = user.Surname,
                    email = user.Email,
                    status = 1
                });
            }
            catch (Exception ex)
            {
                return Json(new {
                    status = 0
                });
            }
        }

        public JsonResult GetCategory(int id)
        {

            var category = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            return Json(new
            {
                id = category.Id,
                name = category.Name,
                isActive = category.IsActive
            });
        }

        public JsonResult Category(int id, string name, bool isActive)

        {
            try
            {
                if (dbContext.Categories.Where(q => q.Id != id).Any(c => c.Name.Trim() == name.Trim()))
                    return Json(new { status = 2 });
                var categoryEntity = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
                categoryEntity.Name = name;
                categoryEntity.IsActive = isActive;

                dbContext.SaveChanges();

                return Json(new
                {
                    status = 1
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 0
                });
            }
        }

        public JsonResult GetQuestion(int id)
        {

            var question = dbContext.Questions.Where(q => q.Id == id).FirstOrDefault();

            return Json(new
            {
                id = question.Id,
                question = question.QuestionTxt,
                optionA = question.OptionA,
                optionB = question.OptionB,
                optionC = question.OptionC,
                optionD = question.OptionD,
                correctOption = dbContext.CorrectAnswers.Where(a => a.QuestionId == id).FirstOrDefault().CorrectOption,
                category = question.CategoryId,
                categoryName = dbContext.Categories.Where(c => c.Id == question.CategoryId).Select(c => c.Name).FirstOrDefault(),
                level = question.Level
            });
        }

        public JsonResult Question(string question, string optionA, string optionB, string optionC, string optionD, string correct, int categoryId, int level, int id)
        {
            try
            {
                var questionEntity = dbContext.Questions.Where(q => q.Id == id).FirstOrDefault();
                questionEntity.QuestionTxt = question;
                questionEntity.OptionA = optionA;
                questionEntity.OptionB = optionB;
                questionEntity.OptionC = optionC;
                questionEntity.OptionD = optionD;
                questionEntity.CategoryId = categoryId;
                questionEntity.Level = level;

                var correctAnswer = dbContext.CorrectAnswers.Where(a => a.QuestionId == id).FirstOrDefault();
                correctAnswer.CorrectOption = correct;

                dbContext.SaveChanges();

                return Json(
                    new
                    {
                        status = 1
                    }
                );

            }
            catch (Exception)
            {

                return Json(
                    new
                    {
                        status = 0
                    }
                );
            }
        }

        public JsonResult Password(string OldPassword, string NewPassword)
        {
            try
            {
                //if (Session["userId"] == null || Session["userType"] == null || Session["userName"] == null || Session["surName"] == null || Session["userEmail"] == null)
                //return Json(new { status = 0 });
                int userID = Convert.ToInt32(Session["userId"]);
                var user = dbContext.Users.Where(u => u.Id == userID && u.Password == OldPassword.Trim()).FirstOrDefault();
                if(user == null)
                    return Json(new { status = 2 });

                user.Password = NewPassword;
                dbContext.SaveChanges();
                return Json(new { status = 1 });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0 });
            }

        }
    }
}