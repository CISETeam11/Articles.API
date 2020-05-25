using Articles.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Data
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }
    }
}