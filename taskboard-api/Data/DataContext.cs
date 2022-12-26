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
        public DbSet<IssueStatus> IssueStatuses => Set<IssueStatus>();
        public DbSet<AvailableStatus> AvailableStatuses => Set<AvailableStatus>();
        public DbSet<Lane> Lanes => Set<Lane>();

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

            modelBuilder.Entity<Lane>()
                .HasMany(l => l.IssuesInLane)
                .WithOne(i => i.CurrentLane)
                .HasForeignKey(i => i.CurrentLaneId);

            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole { UserRoleId = 1, UserRoleName = "Developer" },
                    new UserRole { UserRoleId = 2, UserRoleName = "Business User" },
                    new UserRole { UserRoleId = 3, UserRoleName = "Product Manager" },
                    new UserRole { UserRoleId = 4, UserRoleName = "Admin" }
                );

            modelBuilder.Entity<Lane>()
                .HasData(
                    new Lane { LaneId = 1, LaneName = "To Do"},
                    new Lane { LaneId = 2, LaneName = "In Progress" },
                    new Lane { LaneId = 3, LaneName = "Testing" },
                    new Lane { LaneId = 4, LaneName = "Complete"}
                );

            modelBuilder.Entity<IssueStatus>()
                .HasData(
                    new IssueStatus { IssueStatusId = 1, IssueStatusName = "Not Started" },
                    new IssueStatus { IssueStatusId = 2, IssueStatusName = "Information Needed" },
                    new IssueStatus { IssueStatusId = 3, IssueStatusName = "Development" },
                    new IssueStatus { IssueStatusId = 4, IssueStatusName = "Ready To Test" },
                    new IssueStatus { IssueStatusId = 5, IssueStatusName = "Failed Testing" },
                    new IssueStatus { IssueStatusId = 6, IssueStatusName = "Passed Testing" },
                    new IssueStatus { IssueStatusId = 7, IssueStatusName = "Ready To Deploy" },
                    new IssueStatus { IssueStatusId = 8, IssueStatusName = "Deployed" }
                );

            modelBuilder.Entity<AvailableStatus>()
                .HasData(
                    // "Not Started" availabkle to all users in "To Do" lane
                    new AvailableStatus 
                    { 
                        AvailableStatusId = 1,
                        LaneId = 1,
                        IssueStatusId = 1,
                        UserRoleId = 1 
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 2,
                        LaneId = 1,
                        IssueStatusId = 1,
                        UserRoleId = 2
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 3,
                        LaneId = 1,
                        IssueStatusId = 1,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 4,
                        LaneId = 1,
                        IssueStatusId = 1,
                        UserRoleId = 4
                    },

                    // "Information Needed" available to all users in "To Do" lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 5,
                        LaneId = 1,
                        IssueStatusId = 2,
                        UserRoleId = 1
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 6,
                        LaneId = 1,
                        IssueStatusId = 2,
                        UserRoleId = 2
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 7,
                        LaneId = 1,
                        IssueStatusId = 2,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 8,
                        LaneId = 1,
                        IssueStatusId = 2,
                        UserRoleId = 4
                    },

                    // "Development" available to Dev, PM, and Admin in "In Progress" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 9,
                        LaneId = 2,
                        IssueStatusId = 3,
                        UserRoleId = 1
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 10,
                        LaneId = 2,
                        IssueStatusId = 3,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 11,
                        LaneId = 2,
                        IssueStatusId = 3,
                        UserRoleId = 4
                    },

                    // "Ready To Test" available to Dev, PM, and Admin in "Testing" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 12,
                        LaneId = 3,
                        IssueStatusId = 4,
                        UserRoleId = 1
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 13,
                        LaneId = 3,
                        IssueStatusId = 4,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 14,
                        LaneId = 3,
                        IssueStatusId = 4,
                        UserRoleId = 4
                    },

                    // "Failed Testing" available to Business User, PM, and Admin in "Testing" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 15,
                        LaneId = 3,
                        IssueStatusId = 5,
                        UserRoleId = 2
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 16,
                        LaneId = 3,
                        IssueStatusId = 5,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 17,
                        LaneId = 3,
                        IssueStatusId = 5,
                        UserRoleId = 4
                    },

                    // "Passed Testing" available to Business User, PM, and Admin in "Testing" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 18,
                        LaneId = 3,
                        IssueStatusId = 6,
                        UserRoleId = 2
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 19,
                        LaneId = 3,
                        IssueStatusId = 6,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 20,
                        LaneId = 3,
                        IssueStatusId = 6,
                        UserRoleId = 4
                    },

                    // "Ready To Deploy" available to Dev, PM, and Admin in "Complete" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 21,
                        LaneId = 4,
                        IssueStatusId = 7,
                        UserRoleId = 1
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 22,
                        LaneId = 4,
                        IssueStatusId = 7,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 23,
                        LaneId = 4,
                        IssueStatusId = 7,
                        UserRoleId = 4
                    },

                    // "Deployed" available to Dev, PM, and Admin in "Complete" Lane
                    new AvailableStatus
                    {
                        AvailableStatusId = 24,
                        LaneId = 4,
                        IssueStatusId = 8,
                        UserRoleId = 1
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 25,
                        LaneId = 4,
                        IssueStatusId = 8,
                        UserRoleId = 3
                    },
                    new AvailableStatus
                    {
                        AvailableStatusId = 26,
                        LaneId = 4,
                        IssueStatusId = 8,
                        UserRoleId = 4
                    }
                );
        }
    }
}
