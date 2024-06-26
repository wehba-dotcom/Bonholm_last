using FæsteProtokollerBog.Models;
using Microsoft.EntityFrameworkCore;

namespace FæsteProtokollerBog.Data
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
        { }
        public DbSet<FPBog> FæsteProtokollerBog { get; set; }
        
    }
}
