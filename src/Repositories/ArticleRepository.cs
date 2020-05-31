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

        public Task<bool> ExistsAsync(int articleId)
        {
            return _context.Articles.AsNoTracking().AnyAsync(x => x.ArticleId == articleId);
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.AsNoTracking().Select(a => new Article
            {
                ArticleId = a.ArticleId,
                Author = a.Author,
                Title = a.Title,
                Journal = a.Journal,
                Year = a.Year,
                JournalIssue = a.JournalIssue,
                Volume = a.Volume,
                Pages = a.Pages,
                Doi = a.Doi,
                SoftwareEngineeringMethods = a.SoftwareEngineeringMethods,
                SoftwareEngineeringMethodologies = a.SoftwareEngineeringMethodologies,
                Methods = a.SoftwareEngineeringMethods.Select(method => method.Method),
                Methodologies = a.SoftwareEngineeringMethodologies.Select(methodology => methodology.Methodology),
                Results = a.Results,
                NumberOfRatings = a.UserRatings.Select(rating => rating.Rating).Count(),
                AverageRating = Math.Round(a.UserRatings.Select(rating => rating.Rating).DefaultIfEmpty().Average(), 1)
            }).ToListAsync();
        }

        public async Task<Article> GetArticleAsync(int articleId)
        {
            return await _context.Articles.AsNoTracking().Where(a => a.ArticleId == articleId).Select(a => new Article
            {
                ArticleId = a.ArticleId,
                Author = a.Author,
                Title = a.Title,
                Journal = a.Journal,
                Year = a.Year,
                JournalIssue = a.JournalIssue,
                Volume = a.Volume,
                Pages = a.Pages,
                Doi = a.Doi,
                SoftwareEngineeringMethods = a.SoftwareEngineeringMethods,
                SoftwareEngineeringMethodologies = a.SoftwareEngineeringMethodologies,
                Methods = a.SoftwareEngineeringMethods.Select(method => method.Method),
                Methodologies = a.SoftwareEngineeringMethodologies.Select(methodology => methodology.Methodology),
                Results = a.Results,
                NumberOfRatings = a.UserRatings.Select(rating => rating.Rating).Count(),
                AverageRating = Math.Round(a.UserRatings.Select(rating => rating.Rating).DefaultIfEmpty().Average(), 1)
            }).FirstOrDefaultAsync();
        }

        public async Task AddUserRatingAsync(int articleId, UserRating userRating)
        {
            userRating.ArticleId = articleId;

            await _context.UserRatings.AddAsync(userRating);
            await _context.SaveChangesAsync();
        }
    }
}