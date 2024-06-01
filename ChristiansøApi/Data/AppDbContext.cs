using ChristiansøApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChristiansøApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<Christiansø> Christiansø_personale { get; set; }
    }
}
