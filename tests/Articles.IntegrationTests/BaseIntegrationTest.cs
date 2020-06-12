using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Articles.API;
using Articles.API.Data;
using Articles.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace Articles.IntegrationTests
{
    public class BaseIntegrationTest
    {
        protected static HttpClient Client { get; private set; }

        protected BaseIntegrationTest()
        {
            Client ??= new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Remove the ArticleDbContext registration
                    var descriptor =
                        services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<ArticleDbContext>));

                    if (descriptor != null)
                        services.Remove(descriptor);

                    services.AddDbContext<ArticleDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("IntegrationTestsDb");
                    });

                    // Build the service provider
                    var serviceProvider = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database context
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var dbContext = scopedServices.GetRequiredService<ArticleDbContext>();

                        // Ensure the database is created.
                        dbContext.Database.EnsureCreated();

                        try
                        {
                            // Seed the database with test data
                            SeedData(dbContext);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                });
            }).CreateClient();
        }

        private static void SeedData(ArticleDbContext dbContext)
        {
            dbContext.Articles.AddRange(new List<Article>
            {
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
            });

            dbContext.Methods.AddRange(
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

            dbContext.Methodologies.AddRange(
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

            dbContext.UserRatings.AddRange(
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

            dbContext.SaveChanges();
        }

        protected static async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await Client.GetAsync(endpoint);
        }

        protected static async Task<string> GetStringAsync(string endpoint)
        {
            return await Client.GetStringAsync(endpoint);
        }

        protected static async Task<HttpResponseMessage> PostAsync(string url, object obj)
        {
            // Arrange
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            // Act
            return await Client.PostAsync(url, content);
        }
    }
}