using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class CorrectAnswer
    {
        public int Id { get; set; }
        public string CorrectOption { get; set; }
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}