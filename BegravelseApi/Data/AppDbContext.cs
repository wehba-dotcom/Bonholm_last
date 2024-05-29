using BegravelseApi.Models;

using Microsoft.EntityFrameworkCore;

namespace BegravelseApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<Begrav> Begravelseprotokoller { get; set; }
    }
}
