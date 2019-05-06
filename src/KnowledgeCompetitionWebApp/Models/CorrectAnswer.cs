using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class CorrectAnswer
    {
        public int Id { get; set; }
        public string CorrectOption { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}