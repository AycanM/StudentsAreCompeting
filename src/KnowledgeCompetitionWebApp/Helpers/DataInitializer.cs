using KnowledgeCompetitionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Helpers
{
    public class DataInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context dbContext)
        {
            List<User> users = new List<Models.User>()
            {
                new User(){ Name = "Aycan", Surname = "Mintaş", Email = "aycanmintas@gmail.com", Password = "aycan.mintas0", UserType = 0 },
                new User(){ Name = "Berkant", Surname = "Çeker", Email = "berkantceker@gmail.com", Password = "berkant.ceker1", UserType = 1 },
                new User(){ Name = "Emre", Surname = "Gökgöz", Email = "emregokgoz@gmail.com", Password = "emre.gokgoz2", UserType = 2 },
                new User(){ Name = "Student", Surname = "One", Email = "student1@gmail.com", Password = "testpass", UserType = 2 },
                new User(){ Name = "Student", Surname = "Two", Email = "student2@gmail.com", Password = "testpass", UserType = 2 },
            };

            List<Category> categories = new List<Category>()
            {
                new Category(){Id=1, Name = "CATEGORY1", Color="bg-red", IsActive = true},
                new Category(){Id=2, Name = "CATEGORY2", Color="bg-light-green", IsActive = true},
                new Category(){Id=3, Name = "CATEGORY3", Color="bg-light-blue", IsActive = true}
            };

            List<Question> questions = new List<Question>()
            {
                #region CAT1
                new Question(){ Id=1, QuestionTxt ="1QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 1},
                new Question(){ Id=2, QuestionTxt ="2QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 1},
                new Question(){ Id=3, QuestionTxt ="3QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 1},
                new Question(){ Id=4, QuestionTxt ="4QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 1},
                new Question(){ Id=5, QuestionTxt ="1QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 1},
                new Question(){ Id=6, QuestionTxt ="2QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 1},
                new Question(){ Id=7, QuestionTxt ="3QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 1},
                new Question(){ Id=8, QuestionTxt ="1QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 1},
                new Question(){ Id=9, QuestionTxt ="2QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 1},
                new Question(){ Id=10, QuestionTxt ="1QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 1},
                new Question(){ Id=11, QuestionTxt ="2QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 1},
                new Question(){ Id=12, QuestionTxt ="3QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 1},
                new Question(){ Id=13, QuestionTxt ="1QuestionL5", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 5, CategoryId = 1},
                new Question(){ Id=14, QuestionTxt ="2QuestionL5", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 5, CategoryId = 1},
                new Question(){ Id=15, QuestionTxt ="1QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 1},
                new Question(){ Id=16, QuestionTxt ="2QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 1},
                new Question(){ Id=17, QuestionTxt ="3QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 1},
                new Question(){ Id=18, QuestionTxt ="1QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 1},
                new Question(){ Id=19, QuestionTxt ="2QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 1},
                new Question(){ Id=20, QuestionTxt ="3QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 1},
                new Question(){ Id=21, QuestionTxt ="1QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 1},
                new Question(){ Id=22, QuestionTxt ="2QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 1},
                new Question(){ Id=23, QuestionTxt ="3QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 1},
                new Question(){ Id=24, QuestionTxt ="1QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 1},
                new Question(){ Id=25, QuestionTxt ="2QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 1},
                new Question(){ Id=26, QuestionTxt ="3QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 1},
                new Question(){ Id=27, QuestionTxt ="1QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 1},
                new Question(){ Id=28, QuestionTxt ="2QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 1},
                new Question(){ Id=79, QuestionTxt ="3QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 1},
            #endregion

                #region CAT2
                new Question(){ Id=29, QuestionTxt ="1QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 2},
                new Question(){ Id=30, QuestionTxt ="2QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 2},
                new Question(){ Id=31, QuestionTxt ="3QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 2},
                new Question(){ Id=32, QuestionTxt ="4QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 2},
                new Question(){ Id=33, QuestionTxt ="1QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 2},
                new Question(){ Id=34, QuestionTxt ="2QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 2},
                new Question(){ Id=35, QuestionTxt ="3QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 2},
                new Question(){ Id=36, QuestionTxt ="1QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 2},
                new Question(){ Id=37, QuestionTxt ="2QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 2},
                new Question(){ Id=38, QuestionTxt ="1QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 2},
                new Question(){ Id=39, QuestionTxt ="2QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 2},
                new Question(){ Id=40, QuestionTxt ="3QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 2},
                new Question(){ Id=41, QuestionTxt ="1QuestionL5", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 5, CategoryId = 2},
                new Question(){ Id=42, QuestionTxt ="2QuestionL5", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 5, CategoryId = 2},
                new Question(){ Id=43, QuestionTxt ="1QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 2},
                new Question(){ Id=44, QuestionTxt ="2QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 2},
                new Question(){ Id=45, QuestionTxt ="3QuestionL6", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 6, CategoryId = 2},
                new Question(){ Id=46, QuestionTxt ="1QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 2},
                new Question(){ Id=47, QuestionTxt ="2QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 2},
                new Question(){ Id=48, QuestionTxt ="3QuestionL7", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 7, CategoryId = 2},
                new Question(){ Id=49, QuestionTxt ="1QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 2},
                new Question(){ Id=50, QuestionTxt ="2QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 2},
                new Question(){ Id=51, QuestionTxt ="3QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 2},
                new Question(){ Id=52, QuestionTxt ="1QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 2},
                new Question(){ Id=53, QuestionTxt ="2QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 2},
                new Question(){ Id=54, QuestionTxt ="3QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 2},
                new Question(){ Id=55, QuestionTxt ="1QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 2},
                new Question(){ Id=56, QuestionTxt ="2QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 2},
                new Question(){ Id=57, QuestionTxt ="3QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 2},
            #endregion

                #region CAT3
                new Question(){ Id=58, QuestionTxt ="1QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 3},
                new Question(){ Id=59, QuestionTxt ="2QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 3},
                new Question(){ Id=60, QuestionTxt ="3QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 3},
                new Question(){ Id=61, QuestionTxt ="4QuestionL1", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 1, CategoryId = 3},
                new Question(){ Id=62, QuestionTxt ="1QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 3},
                new Question(){ Id=63, QuestionTxt ="2QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 3},
                new Question(){ Id=64, QuestionTxt ="3QuestionL2", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 2, CategoryId = 3},
                new Question(){ Id=65, QuestionTxt ="1QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 3},
                new Question(){ Id=66, QuestionTxt ="2QuestionL3", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 3, CategoryId = 3},
                new Question(){ Id=67, QuestionTxt ="1QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 3},
                new Question(){ Id=68, QuestionTxt ="2QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 3},
                new Question(){ Id=69, QuestionTxt ="3QuestionL4", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 4, CategoryId = 3},
                new Question(){ Id=70, QuestionTxt ="1QuestionL5", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 5, CategoryId = 3},
                new Question(){ Id=71, QuestionTxt ="2QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 3},
                new Question(){ Id=72, QuestionTxt ="3QuestionL8", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 8, CategoryId = 3},
                new Question(){ Id=73, QuestionTxt ="1QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 3},
                new Question(){ Id=74, QuestionTxt ="2QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 3},
                new Question(){ Id=75, QuestionTxt ="3QuestionL9", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 9, CategoryId = 3},
                new Question(){ Id=76, QuestionTxt ="1QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 3},
                new Question(){ Id=77, QuestionTxt ="2QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 3},
                new Question(){ Id=78, QuestionTxt ="3QuestionL10", OptionA="OptionA", OptionB="OptionB", OptionC="OptionC", OptionD="OptionD", Level = 10, CategoryId = 3}
            #endregion
            };

            List<CorrectAnswer> answers = new List<CorrectAnswer>();
            Random r = new Random();
            for (int i = 1; i < 80; i++)
            {
                int rNum = r.Next(1, 5);
                string corOpt = string.Empty;
                switch (rNum)
                {
                    case 1:
                        corOpt = "a";
                          break;
                    case 2:
                        corOpt = "b";
                        break;
                    case 3:
                        corOpt = "c";
                        break;
                    case 4:
                        corOpt = "d";
                        break;

                    default:
                        corOpt = "a";
                        break;
                }

                answers.Add(new CorrectAnswer { CorrectOption = corOpt, QuestionId = i});
            }
            
            //Veritabanına seed data ekleniyor
            foreach (var user in users)
            {
                dbContext.Users.Add(user);
            }

            foreach (var category in categories)
            {
                dbContext.Categories.Add(category);
            }

            foreach (var question in questions)
            {
                dbContext.Questions.Add(question);
            }

            foreach (var corAnswer in answers)
            {
                dbContext.CorrectAnswers.Add(corAnswer);
            }

            dbContext.SaveChanges();

            base.Seed(dbContext);
        }
    }
}