using Articles.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Author = "Runeson",
                    Title = "Guidelines for conducting and reporting case study research in software engineering",
                    Journal = "Empirical Software Engineering",
                    Year = 2008,
                    Volume = 14,
                    JournalIssue = 2,
                    Pages = "131-164",
                    Doi = "10.1007/s10664-008-9102-8"
                }
            );
        }
    }
}