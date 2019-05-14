using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class ResultsToDisplay
    {
        public int CompetitionId { get; set; }
        public int QuestionsCount { get; set; }
        public int AnsweredCount { get; set; }
        public string CategoryName { get; set; }
        public string CompetitionDate { get; set; }

    }
}