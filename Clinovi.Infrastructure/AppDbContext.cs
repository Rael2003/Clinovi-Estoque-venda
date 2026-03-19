using Clinovi.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clinovi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}