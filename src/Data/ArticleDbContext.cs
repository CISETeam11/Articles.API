using Articles.API.Extensions;
using Articles.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.API.Data
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<SoftwareEngineeringMethod> Methods { get; set; }
        public DbSet<SoftwareEngineeringMethodology> Methodologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}