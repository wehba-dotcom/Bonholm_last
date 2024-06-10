using FT1845Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FT1845Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<FT> FT1845 { get; set; }
    }
}
