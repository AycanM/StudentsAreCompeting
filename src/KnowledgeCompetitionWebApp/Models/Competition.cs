using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string CompetitionCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
        public List<Question> Questions { get; set; }
    }
}