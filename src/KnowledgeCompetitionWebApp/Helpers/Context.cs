using KnowledgeCompetitionWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnowledgeCompetitionWebApp.Helpers
{
    public class Context : DbContext
    {

        public Context() : base()
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}