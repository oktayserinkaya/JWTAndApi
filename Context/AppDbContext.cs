using JWTAndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAndApi.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
