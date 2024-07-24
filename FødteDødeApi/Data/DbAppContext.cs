using FødteDødeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FødteDødeApi.Data
{
    public class DbAppContext:DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }
       public DbSet<FødteDøde> FødteDøde { get; set; }

    }
}
