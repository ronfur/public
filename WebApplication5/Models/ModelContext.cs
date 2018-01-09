
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=model.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bundle>().HasMany<BundlePath>(i => i.BundlePaths);

            modelBuilder.Entity<BundlePath>()
    .HasKey(bc => new { bc.Id });
//    .HasKey(bc => new { bc.BundleId, bc.PathId});
            /*
            modelBuilder.Entity<BundlePath>()
                .HasOne(bc => bc.Bundle)
                .WithMany(b => b.BundlePaths)
                .HasForeignKey(bc => bc.BundleId);

            modelBuilder.Entity<BundlePath>()
                .HasOne(bc => bc.Path)
                .WithMany(c => c.BundlePaths)
                .HasForeignKey(bc => bc.PathId);*/
        }
    }
}
