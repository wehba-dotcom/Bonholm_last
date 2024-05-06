using AfgangTilgangApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AfgangTilgangApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<AfgangTilgang> AfgangTilgang { get; set; }
    }
}
