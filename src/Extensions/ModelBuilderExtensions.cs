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
                    ArticleId = 1,
                    Author = "P. Runeson, M. Höst",
                    Title = "Guidelines for conducting and reporting case study research in software engineering",
                    Journal = "Empirical Software Engineering",
                    Year = 2008,
                    Volume = 14,
                    JournalIssue = 2,
                    Pages = "131-164",
                    Doi = "10.1007/s10664-008-9102-8"
                },
                new Article
                {
                    ArticleId = 2,
                    Author = "M. F. Aniche, M. A. Gerosa",
                    Title = "Most Common Mistakes in Test-Driven Development Practice: Results from an Online Survey with Developers",
                    Journal = "ieeexplore.ieee.org",
                    Year = 2010,
                    Pages = "469-478",
                    Doi = "10.1109/ICSTW.2010.16"
                }
            );

            modelBuilder.Entity<SoftwareEngineeringMethod>().HasData(
                new SoftwareEngineeringMethod
                {
                    Id = 1,
                    ArticleId = 1,
                    Method = "TDD"
                },
                new SoftwareEngineeringMethod
                {
                    Id = 2,
                    ArticleId = 1,
                    Method = "Continuous Integration"
                },
                new SoftwareEngineeringMethod
                {
                    Id = 3,
                    ArticleId = 2,
                    Method = "TDD"
                }
            );

            modelBuilder.Entity<SoftwareEngineeringMethodology>().HasData(
                new SoftwareEngineeringMethodology
                {
                    Id = 1,
                    ArticleId = 1,
                    Methodology = "Agile"
                },
                new SoftwareEngineeringMethodology
                {
                    Id = 2,
                    ArticleId = 1,
                    Methodology = "XP"
                },
                new SoftwareEngineeringMethodology
                {
                    Id = 3,
                    ArticleId = 2,
                    Methodology = "Agile"
                }
            );

            modelBuilder.Entity<UserRating>().HasData(
                new UserRating
                {
                    Id = 1,
                    ArticleId = 1,
                    Rating = 3
                },
                new UserRating
                {
                    Id = 2,
                    ArticleId = 1,
                    Rating = 2
                },
                new UserRating
                {
                    Id = 3,
                    ArticleId = 1,
                    Rating = 2
                }
            );
        }
    }
}