using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Articles.API.Contracts;
using Articles.API.Models;
using Microsoft.AspNet.OData;
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
        [EnableQuery]
        [ProducesResponseType(typeof(IEnumerable<Article>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllArticlesAsync([FromQuery] ArticleQueryParameter queryParameters)
        {
            return Ok(await _articleRepository.GetAllAsync(queryParameters));
        }

        [HttpGet("{articleId}")]
        [ProducesResponseType(typeof(Article), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetArticleAsync(int articleId)
        {
            if (!await ArticleExistsAsync(articleId))
                return NotFound();

            return Ok(await _articleRepository.GetArticleAsync(articleId));
        }

        [HttpPost("{articleId}/userRating")]
        [ProducesResponseType(typeof(UserRating), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostArticleUserRatingAsync([BindRequired] int articleId,
            [FromBody] [BindRequired] UserRating userRating)
        {
            if (!await ArticleExistsAsync(articleId))
                return NotFound();

            await _articleRepository.AddUserRatingAsync(articleId, userRating);

            return CreatedAtAction(
                nameof(GetArticleAsync),
                new {articleId},
                userRating
            );
        }
    }
}