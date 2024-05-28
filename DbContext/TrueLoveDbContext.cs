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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}