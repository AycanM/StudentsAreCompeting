using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string SelectedOption { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public List<Question> Questions { get; set; }
    }
}