using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Articles.API.Models;
using Newtonsoft.Json;
using Xunit;

namespace Articles.IntegrationTests.Endpoints
{
    public class GetEndpointsTest : BaseIntegrationTest
    {
        [Theory]
        [InlineData("/api/articles")]
        [InlineData("/api/articles/1")]
        public async Task Get_Endpoints_Return_Success_And_Correct_Content_Type(string endpoint)
        {
            // Act
            var response = await GetAsync(endpoint);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/articles/123")]
        public async Task Get_Endpoints_Return_Not_Found(string endpoint)
        {
            // Act
            var response = await GetAsync(endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/articles/null")]
        [InlineData("/api/articles/abc")]
        [InlineData("/api/articles/%20")]
        [InlineData("/api/articles/ /")]
        public async Task Get_Endpoints_Return_Bad_Request(string endpoint)
        {
            // Act
            var response = await GetAsync(endpoint);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Articles_Return_Article_Collection()
        {
            // Arrange
            const string url = "/api/articles";

            // Act
            var json = await GetStringAsync(url);
            var articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(json);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Article>>(articles);
        }

        [Fact]
        public async Task Get_Article_With_Article_Id_Validate_Properties()
        {
            // Arrange
            const string url = "/api/articles/1";

            // Act
            var json = await GetStringAsync(url);
            var article = JsonConvert.DeserializeObject<Article>(json);

            // Assert
            Assert.IsAssignableFrom<Article>(article);

            Assert.Equal(1, article.ArticleId);
            Assert.Equal("Per Runeson, Martin Höst", article.Author);
            Assert.Equal("Guidelines for conducting and reporting case study research in software engineering", article.Title);
            Assert.Equal("Empirical Software Engineering", article.Journal);
            Assert.Equal(2008, article.Year);
            Assert.Equal(2, article.JournalIssue);
            Assert.Equal(14, article.Volume);
            Assert.Equal("131-164", article.Pages);
            Assert.Equal("10.1007/s10664-008-9102-8", article.Doi);
            Assert.NotEmpty(article.Methods);
            Assert.NotEmpty(article.Methodologies);
            Assert.Equal(2.8, article.AverageRating);
            Assert.Equal(4, article.NumberOfRatings);
        }
    }
}