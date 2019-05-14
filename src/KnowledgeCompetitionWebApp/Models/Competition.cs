using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        public List<Question> Questions { get; set; }
        public List<Result> Results { get; set; }
    }
}