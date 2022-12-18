using Microsoft.EntityFrameworkCore;
using taskboard_api.Models;

namespace taskboard_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>()
                .HasOne<User>(i => i.SubmittedBy)
                .WithMany(u => u.IssuesSubmitted);

            modelBuilder.Entity<Issue>()
                .HasOne<User>(i => i.AssignedTo)
                .WithMany(u => u.AssignedIssues);
        }
    }
}
