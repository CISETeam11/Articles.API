using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.API.Models;

namespace Articles.API.Contracts
{
    public interface IArticleRepository
    {
        Task<bool> ExistsAsync(int articleId);
        Task<IEnumerable<Article>> GetAllAsync(ArticleQueryParameter queryParameters);
        Task<Article> GetArticleAsync(int articleId);
        Task AddUserRatingAsync(int articleId, UserRating userRating);
    }
}