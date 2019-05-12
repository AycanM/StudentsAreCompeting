using KnowledgeCompetitionWebApp.Helpers;
using KnowledgeCompetitionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeCompetitionWebApp.Controllers
{
    public class SaveController : Controller
    {
        public Context dbContext { get; set; }
        public SaveController()
        {
            dbContext = new Context();
        }


        public JsonResult User(string name, string surname, string email, string password, int userType)
        {
            try
            {
                if (dbContext.Users.Any(p => p.Email.Trim() == email.Trim()))
                    return Json(new { status = 2 });
                User user = new User
                {
                    Name = name,
                    Surname = surname,
                    Password = password,
                    Email = email,
                    UserType = userType
                };

                dbContext.Users.Add(user);
                dbContext.SaveChangesAsync();
                return Json(new { status = 1 });

            }
            catch (Exception ex)
            {
                return Json(new { status = 0 });
            }
        }

        public JsonResult Category(string categoryName, string color, bool isActive)
        {
            try
            {
                if (dbContext.Categories.Any(c => c.Name.ToLower().Trim() == categoryName.ToLower().Trim()))
                    return Json(new { status = 2 });

                if (string.IsNullOrEmpty(categoryName))
                    throw new Exception();
                Category category = new Category
                {
                    Name = categoryName,
                    Color = color,
                    IsActive = isActive
                };

                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                return Json(new { status = 1 });

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

        public JsonResult Question(string question, string optionA, string optionB, string optionC, string optionD, string correct, int categoryId, int level)
        {
            try
            {
                if (string.IsNullOrEmpty(question) || string.IsNullOrEmpty(optionA) || string.IsNullOrEmpty(optionB) ||
                    string.IsNullOrEmpty(optionC) || string.IsNullOrEmpty(optionD) || string.IsNullOrEmpty(correct) || categoryId <= 0)
                    throw new Exception();
                Question questionEntity = new Question
                {
                    QuestionTxt = question,
                    OptionA = optionA,
                    OptionB = optionB,
                    OptionC = optionC,
                    OptionD = optionD,
                    CategoryId = categoryId,
                    Level = level
                };

                dbContext.Questions.Add(questionEntity);

                var questionId = questionEntity.Id;

                CorrectAnswer correctEntity = new CorrectAnswer
                {
                    CorrectOption = correct,
                    QuestionId = questionId
                };

                dbContext.CorrectAnswers.Add(correctEntity);

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

        public JsonResult Competition(int id = -1)
        {
            try
            {
                List<Question> CompetitionQuestions = new List<Question>();
                Random randomQuestionIndex = new Random();
                if (id == -1)
                    throw new Exception();
                if (Session["userType"] == null || Convert.ToInt32(Session["userType"]) != 2)
                    return Json(new { status = 2 });
                var questions = dbContext.Questions.Where(q => q.CategoryId == id).ToList();

                for (int i = 1; i < 11; i++)
                {
                    int questionCount = questions.Count(q => q.Level == i);
                    int index = randomQuestionIndex.Next(0, questionCount);

                    var questionsInLevel = questions.Where(q => q.Level == i).ToList();

                    CompetitionQuestions.Add(questionsInLevel[index]);
                }

                Guid guid = Guid.NewGuid();
                string competitionCode = Convert.ToBase64String(guid.ToByteArray());
                competitionCode = competitionCode.Replace("=", "")
                                                 .Replace("+", "")
                                                 .Replace("-", "")
                                                 .Replace("/", "");
                int userId = Convert.ToInt32(Session["userId"]);
                Competition competition = new Competition
                {
                    CompetitionCode = competitionCode,
                    CreatedDate = DateTime.Now,
                    Questions = CompetitionQuestions,
                    UserId = userId
                };

                dbContext.Competitions.Add(competition);
                dbContext.SaveChanges();
                return Json(
                    new
                    {
                        status = 1,
                        code = competitionCode
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

        public JsonResult Result(string selectedOption, int competitionId = 0)
        {
            try
            {
                if (Session["userType"] == null || Convert.ToInt32(Session["userType"]) != 2)
                    return Json(new { status = 2 });
                if (competitionId == 0 || string.IsNullOrEmpty(selectedOption))
                    throw new Exception();

                var result = new Result
                {
                    CompetitionId = competitionId,
                    SelectedOption = selectedOption
                };

                dbContext.Results.Add(result);
                dbContext.SaveChanges();

                return Json(new { status = 1 });
            }
            catch (Exception)
            {
                dbContext.Results.RemoveRange(dbContext.Results.Where(r => r.CompetitionId == competitionId));
                dbContext.SaveChanges();
                return Json(new { status = 0 });
            }
            
        }
    }
}