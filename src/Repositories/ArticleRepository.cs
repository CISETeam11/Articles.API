using System;
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

        private static Article IncludeArticleData(Article article)
        {
            article.Methods = article.SoftwareEngineeringMethods.Select(x => x.Method).ToList();
            article.Methodology = article.SoftwareEngineeringMethodologies.Select(x => x.Methodology)
                .ToList();
            article.AverageRating = Math.Round(article.UserRatings.Select(x => x.Rating).DefaultIfEmpty(0).Average(), 1);
            article.NumberOfRatings = article.UserRatings.Count();

            return article;
        }

        public Task<bool> ExistsAsync(int articleId)
        {
            return _context.Articles.AsNoTracking().AnyAsync(x => x.ArticleId == articleId);
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            var articles = await _context.Articles.AsNoTracking().Include(a => a.SoftwareEngineeringMethods)
                .Include(a => a.SoftwareEngineeringMethodologies).Include(a => a.UserRatings).ToListAsync();

            foreach (var article in articles)
            {
                IncludeArticleData(article);
            }

            return articles;
        }

        public async Task<Article> GetArticleAsync(int articleId)
        {
            var article = await _context.Articles.AsNoTracking().Include(a => a.SoftwareEngineeringMethods)
                .Include(a => a.SoftwareEngineeringMethodologies).Include(a => a.UserRatings).Where(a => a.ArticleId == articleId)
                .FirstOrDefaultAsync();

            return IncludeArticleData(article);
        }

        public async Task AddUserRatingAsync(int articleId, UserRating userRating)
        {
            userRating.ArticleId = articleId;

            await _context.UserRatings.AddAsync(userRating);
            await _context.SaveChangesAsync();
        }
    }
}