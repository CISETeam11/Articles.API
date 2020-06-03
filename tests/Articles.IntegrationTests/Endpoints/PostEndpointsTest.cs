using System.Net;
using System.Threading.Tasks;
using Articles.IntegrationTests.Data;
using Xunit;

namespace Articles.IntegrationTests.Endpoints
{
    public class PostEndpointsTest : BaseIntegrationTest
    {
        [Theory]
        [MemberData(nameof(PostTestData.SuccessUserRatingTestData), MemberType = typeof(PostTestData))]
        public async Task Post_User_Rating_Return_Created(object articleId, object userRating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating", userRating);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [MemberData(nameof(PostTestData.BadRequestUserRatingTestData), MemberType = typeof(PostTestData))]
        public async Task Post_User_Rating_Return_Bad_Request(object articleId, object userRating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating", userRating);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [MemberData(nameof(PostTestData.NotFoundUserRatingTestData), MemberType = typeof(PostTestData))]
        public async Task Post_User_Rating_Return_Not_Found(object articleId, object userRating)
        {
            // Act
            var response = await PostAsync($"/api/articles/{articleId}/userrating", userRating);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
