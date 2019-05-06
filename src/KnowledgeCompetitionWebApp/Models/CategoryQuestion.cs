using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Models
{
    public class CategoryQuestion
    {
        public List<Category> Categories { get; set; }
        public List<Question> Questions { get; set; }
        public List<CorrectAnswer> CorrectOptions { get; set; }
    }
}