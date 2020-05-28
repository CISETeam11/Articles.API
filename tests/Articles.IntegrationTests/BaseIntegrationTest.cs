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
                        var db = scopedServices.GetRequiredService<ArticleDbContext>();

                        // Ensure the database is created.
                        db.Database.EnsureCreated();

                        try
                        {
                            // Seed the database with test data
                            db.Articles.AddRange(new List<Article>
                            {
                                new Article { ArticleId = 1 },
                                new Article { ArticleId = 2 },
                                new Article { ArticleId = 3 }
                            });

                            db.Methods.Add(new SoftwareEngineeringMethod
                            {
                                Id = 1, ArticleId = 1, Method = "Test"
                            });

                            db.Methodologies.Add(new SoftwareEngineeringMethodology
                            {
                                Id = 1, ArticleId = 1, Methodology = "Test"
                            });

                            db.UserRatings.Add(new UserRating
                            {
                                Id = 1, ArticleId = 1, Rating = 3
                            });

                            db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                });
            }).CreateClient();
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