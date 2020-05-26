using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Articles.API.Contracts;
using Articles.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Articles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private Task<bool> ArticleExistsAsync(int articleId)
        {
            return _articleRepository.ExistsAsync(articleId);
        }

        [HttpGet]
        //[ResponseCache(Duration = 600)]
        [ProducesResponseType(typeof(IEnumerable<Article>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArticlesAsync()
        {
            return Ok(await _articleRepository.GetAllAsync());
        }

        [HttpPost("{articleId}/userRating")]
        [ProducesResponseType(typeof(UserRating), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostArticleUserRating([BindRequired] int articleId, [BindRequired] int rating)
        {
            if (!await ArticleExistsAsync(articleId))
                return NotFound();

            var userRating = new UserRating
            {
                ArticleId = articleId,
                Rating = rating
            };

            await _articleRepository.AddUserRatingAsync(userRating);

            return CreatedAtAction(
                nameof(GetArticlesAsync),
                new {articleId},
                userRating
            );
        }
    }
}