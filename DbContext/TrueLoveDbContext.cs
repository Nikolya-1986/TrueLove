using Love.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Love.DbContext
{
    public class TrueLoveDbContext: IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public TrueLoveDbContext(DbContextOptions<TrueLoveDbContext> options): base(options)
        {
            _options = options;
        }

        public DbSet<MainUserInfo>? MainUserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainUserInfo>(entity =>
            {
                entity.Property(prop => prop.userName)
                .IsRequired()
                .HasMaxLength(30);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}