using System.Threading.Tasks;
using Articles.API.Contracts;
using Articles.API.Controllers;
using Articles.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Articles.UnitTests
{
    public class ArticlesControllerTest
    {
        private readonly Mock<IArticleRepository> _articleRepository;

        public ArticlesControllerTest()
        {
            _articleRepository = new Mock<IArticleRepository>();
        }

        [Fact]
        public async Task Post_User_Rating_With_Created_Response()
        {
            // Arrange
            const int articleId = 1;
            var mockUserRating = new UserRating();
            _articleRepository.Setup(x => x.ExistsAsync(It.IsAny<int>())).ReturnsAsync(true);
            _articleRepository.Setup(x => x.AddUserRatingAsync(It.IsAny<int>(), It.IsAny<UserRating>()))
                .Returns(Task.FromResult(mockUserRating));

            // Act
            var articlesController = new ArticlesController(_articleRepository.Object);
            var actionResult = await articlesController.PostArticleUserRatingAsync(articleId, mockUserRating);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }
    }
}