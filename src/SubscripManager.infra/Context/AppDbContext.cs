using Microsoft.EntityFrameworkCore;
using SubscripManager.domain.Entities;

namespace SubscripManager.infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Signature> Signatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Signature>().HasKey(s => s.Id);

            modelBuilder.Entity<Signature>()
                        .HasOne<User>()
                        .WithMany(u => u.Signatures)
                        .HasForeignKey(s => s.UserId);
        }
    }
}