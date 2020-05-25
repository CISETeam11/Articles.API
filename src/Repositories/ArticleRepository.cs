using System.Collections.Generic;
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
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.AsNoTracking().ToListAsync();
        }
    }
}