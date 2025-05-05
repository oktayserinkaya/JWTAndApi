using JWTAndApi.Models;
using JWTAndApi.SeedData;
using Microsoft.EntityFrameworkCore;

namespace JWTAndApi.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BookSeedData());
        }
    }
}
