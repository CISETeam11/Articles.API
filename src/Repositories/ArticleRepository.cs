using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.API.Contracts;
using Articles.API.Data;
using Articles.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext _context;

        public ArticleRepository(ArticleDbContext context)
        {
            _context = context;

            _context?.Database.EnsureCreated();
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            var articles = await _context.Articles.AsNoTracking().Include(a => a.SoftwareEngineeringMethods)
                .Include(a => a.SoftwareEngineeringMethodologies).ToListAsync();

            foreach (var article in articles)
            {
                article.Methods = article.SoftwareEngineeringMethods.Select(x => x.Method.ToString()).ToList();
                article.Methodology = article.SoftwareEngineeringMethodologies.Select(x => x.Methodology.ToString())
                    .ToList();
            }

            return articles;
        }
    }
}