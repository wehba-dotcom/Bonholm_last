using Dato1822Api.Models;
using Dato1822Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Dato1822Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Dato1822> Dato1822 { get; set; }
    }
}
