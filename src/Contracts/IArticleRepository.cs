using System.Collections.Generic;
using System.Threading.Tasks;
using Articles.API.Models;

namespace Articles.API.Contracts
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync();
    }
}