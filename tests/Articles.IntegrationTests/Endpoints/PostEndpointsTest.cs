using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Articles.IntegrationTests.Endpoints
{
    public class PostEndpointsTest : BaseIntegrationTest
    {
        private static async Task<HttpResponseMessage> PostAsync(string url)
        {
            // Act
            return await Client.PostAsync(url, null);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 2)]
        public async Task Post_Route_Return_Created(int articleId, int rating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating?rating={rating}");

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData(1, "abc")]
        [InlineData(2, null)]
        public async Task Post_Route_Return_Bad_Request(int articleId, string rating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating?rating={rating}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(5, 3)]
        public async Task Post_Route_Return_Conflict(int articleId, int rating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating?rating={rating}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
