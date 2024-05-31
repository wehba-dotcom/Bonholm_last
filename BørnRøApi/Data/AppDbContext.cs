

using BørnRøApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BørnRøApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<Børn> Børn_Rø_1737 { get; set; }
    }
}
