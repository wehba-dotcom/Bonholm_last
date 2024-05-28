using ArrestprotokollerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArrestprotokollerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Arrestprotokoller> Arrestprotokoller { get; set; }
    }
}
