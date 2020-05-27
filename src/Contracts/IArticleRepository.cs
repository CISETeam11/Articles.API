using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.API.Models;

namespace Articles.API.Contracts
{
    public interface IArticleRepository
    {
        Task<bool> ExistsAsync(int articleId);
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> GetArticleAsync(int articleId);
        Task AddUserRatingAsync(UserRating userRating);
    }
}