using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTxt { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int Level { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Competition> Competitions { get; set; }


    }
}