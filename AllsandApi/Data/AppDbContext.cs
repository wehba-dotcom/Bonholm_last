using AllsandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AllsandApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Allsand> Allsand { get; set; }
    }
}
