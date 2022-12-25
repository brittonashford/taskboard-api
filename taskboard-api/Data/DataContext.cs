using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using taskboard_api.DTOs.User;
using taskboard_api.Models;

namespace taskboard_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues => Set<Issue>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.IssuesSubmitted)
                .WithOne(i => i.SubmittedBy)
                .HasForeignKey(i => i.SubmittedById);

            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedIssues)
                .WithOne(i => i.AssignedTo)
                .HasForeignKey(i => i.AssignedToId);

            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole { UserRoleId = 1, RoleType = "Developer" },
                    new UserRole { UserRoleId = 2, RoleType = "ProductManager" },
                    new UserRole { UserRoleId = 3, RoleType = "BusinessUser" },
                    new UserRole { UserRoleId = 4, RoleType = "Admin" }
                );
        }
    }
}
