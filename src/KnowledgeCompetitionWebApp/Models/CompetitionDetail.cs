using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class CompetitionDetail
    {
        public User User { get; set; }
        public Competition Competition { get; set; }
        public List<Question> Questions { get; set; }
        public List<Result> Results { get; set; }
        public List<CorrectAnswer> CorrectAnswers { get; set; }
        public string CategoryName { get; set; }
    }
}