

using BorgerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BorgerskabApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<Borger> Borgerskab_Rønne_1701_66 { get; set; }
    }
}
