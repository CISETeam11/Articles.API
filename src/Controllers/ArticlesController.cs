using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Articles.API.Contracts;
using Articles.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [ResponseCache(Duration = 600)]
        [ProducesResponseType(typeof(IEnumerable<Article>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoutesAsync()
        {
            return Ok(await _articleRepository.GetAllAsync());
        }
    }
}