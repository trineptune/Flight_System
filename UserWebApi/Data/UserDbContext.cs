using Microsoft.EntityFrameworkCore;
using UserWebApi.Models;

namespace UserWebApi.Data
{
    public class UserDbContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.User)
            .HasForeignKey(u => u.RoleId);
        }

    }
}
