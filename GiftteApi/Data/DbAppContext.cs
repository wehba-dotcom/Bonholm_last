using GifteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GifteApi.Data
{
    public class DbAppContext:DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }
       public DbSet<Gifte> gifte { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gifte>()
                .Property(g => g.G_fornavn)
                .IsRequired(false);
            modelBuilder.Entity<Gifte>()
                .Property(g => g.B_fødesogn)
                .IsRequired(false);
            modelBuilder.Entity<Gifte>()
               .Property(g => g.G_fødesogn)
               .IsRequired(false);
            modelBuilder.Entity<Gifte>()
                .Property(g => g.G_efternavn)
                .IsRequired(false);

            modelBuilder.Entity<Gifte>()
                .Property(g => g.G_slægtsnavn)
                .IsRequired(false);

            modelBuilder.Entity<Gifte>()
                .Property(g => g.B_fornavn)
                .IsRequired(false);

            modelBuilder.Entity<Gifte>()
                .Property(g => g.B_efternavn)
                .IsRequired(false);

            modelBuilder.Entity<Gifte>()
                .Property(g => g.B_slægtsnavn)
                .IsRequired(false);
            modelBuilder.Entity<Gifte>()
           .Property(g => g.B_fødeår)
           .IsRequired(false);
            modelBuilder.Entity<Gifte>()
           .Property(g => g.G_fødeaar)
           .IsRequired(false);
            modelBuilder.Entity<Gifte>()
          .Property(g => g.B_haandtering)
          .IsRequired(false);
        }

    }
}
