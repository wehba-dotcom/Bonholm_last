using GårdRegApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GårdRegApi.Data
{
    public class DbAppContext:DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }
       public DbSet<GårdReg> GårdRegistreringer { get; set; }
       
    }
}
