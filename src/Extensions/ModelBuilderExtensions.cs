﻿using Articles.API.Models;
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
                    Author = "Per Runeson, Martin Höst",
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
                    Author = "Mauricio Aniche, Marco Gerosa",
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

            modelBuilder.Entity<SoftwareEngineeringResult>().HasData(
                new SoftwareEngineeringResult
                {
                    Id = 1,
                    ArticleId = 1,
                    Method = "TDD",
                    Result = "TDD improves code quality measured using a Coupling and Cohesion coefficient calculation"
                },
                new SoftwareEngineeringResult
                {
                    Id = 2,
                    ArticleId = 1,
                    Method = "TDD",
                    Result = "Test TDD Result 2"
                },
                new SoftwareEngineeringResult
                {
                    Id = 3,
                    ArticleId = 1,
                    Method = "TDD",
                    Result = "Test TDD Result 3"
                },
                new SoftwareEngineeringResult
                {
                    Id = 4,
                    ArticleId = 1,
                    Method = "Continuous Integration",
                    Result = "Test Continuous Integration Result 1"
                },
                new SoftwareEngineeringResult
                {
                    Id = 5,
                    ArticleId = 2,
                    Method = "TDD",
                    Result = "Test TDD Result 1"
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
                    Rating = 5
                },
                new UserRating
                {
                    Id = 4,
                    ArticleId = 1,
                    Rating = 1
                }
            );
        }
    }
}