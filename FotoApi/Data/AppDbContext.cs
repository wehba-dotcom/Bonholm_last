using FotoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FotoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
       public DbSet<Foto> Foto { get; set; }
    }
}
