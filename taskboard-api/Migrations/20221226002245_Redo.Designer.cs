﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using taskboard_api.Data;

#nullable disable

namespace taskboardapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221226002245_Redo")]
    partial class Redo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("taskboard_api.Models.AvailableStatus", b =>
                {
                    b.Property<int>("AvailableStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailableStatusId"));

                    b.Property<int>("IssueStatusId")
                        .HasColumnType("int");

                    b.Property<int>("LaneId")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("AvailableStatusId");

                    b.ToTable("AvailableStatuses");

                    b.HasData(
                        new
                        {
                            AvailableStatusId = 1,
                            IssueStatusId = 1,
                            LaneId = 1,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 2,
                            IssueStatusId = 1,
                            LaneId = 1,
                            UserRoleId = 2
                        },
                        new
                        {
                            AvailableStatusId = 3,
                            IssueStatusId = 1,
                            LaneId = 1,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 4,
                            IssueStatusId = 1,
                            LaneId = 1,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 5,
                            IssueStatusId = 2,
                            LaneId = 1,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 6,
                            IssueStatusId = 2,
                            LaneId = 1,
                            UserRoleId = 2
                        },
                        new
                        {
                            AvailableStatusId = 7,
                            IssueStatusId = 2,
                            LaneId = 1,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 8,
                            IssueStatusId = 2,
                            LaneId = 1,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 9,
                            IssueStatusId = 3,
                            LaneId = 2,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 10,
                            IssueStatusId = 3,
                            LaneId = 2,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 11,
                            IssueStatusId = 3,
                            LaneId = 2,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 12,
                            IssueStatusId = 4,
                            LaneId = 3,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 13,
                            IssueStatusId = 4,
                            LaneId = 3,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 14,
                            IssueStatusId = 4,
                            LaneId = 3,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 15,
                            IssueStatusId = 5,
                            LaneId = 3,
                            UserRoleId = 2
                        },
                        new
                        {
                            AvailableStatusId = 16,
                            IssueStatusId = 5,
                            LaneId = 3,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 17,
                            IssueStatusId = 5,
                            LaneId = 3,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 18,
                            IssueStatusId = 6,
                            LaneId = 3,
                            UserRoleId = 2
                        },
                        new
                        {
                            AvailableStatusId = 19,
                            IssueStatusId = 6,
                            LaneId = 3,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 20,
                            IssueStatusId = 6,
                            LaneId = 3,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 21,
                            IssueStatusId = 7,
                            LaneId = 4,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 22,
                            IssueStatusId = 7,
                            LaneId = 4,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 23,
                            IssueStatusId = 7,
                            LaneId = 4,
                            UserRoleId = 4
                        },
                        new
                        {
                            AvailableStatusId = 24,
                            IssueStatusId = 8,
                            LaneId = 4,
                            UserRoleId = 1
                        },
                        new
                        {
                            AvailableStatusId = 25,
                            IssueStatusId = 8,
                            LaneId = 4,
                            UserRoleId = 3
                        },
                        new
                        {
                            AvailableStatusId = 26,
                            IssueStatusId = 8,
                            LaneId = 4,
                            UserRoleId = 4
                        });
                });

            modelBuilder.Entity("taskboard_api.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueId"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentLaneId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueStatusId")
                        .HasColumnType("int");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("SubmittedById")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("IssueId");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CurrentLaneId");

                    b.HasIndex("IssueStatusId");

                    b.HasIndex("SubmittedById");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("taskboard_api.Models.IssueStatus", b =>
                {
                    b.Property<int>("IssueStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueStatusId"));

                    b.Property<string>("IssueStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IssueStatusId");

                    b.ToTable("IssueStatuses");

                    b.HasData(
                        new
                        {
                            IssueStatusId = 1,
                            IssueStatusName = "Not Started"
                        },
                        new
                        {
                            IssueStatusId = 2,
                            IssueStatusName = "Information Needed"
                        },
                        new
                        {
                            IssueStatusId = 3,
                            IssueStatusName = "Development"
                        },
                        new
                        {
                            IssueStatusId = 4,
                            IssueStatusName = "Ready To Test"
                        },
                        new
                        {
                            IssueStatusId = 5,
                            IssueStatusName = "Failed Testing"
                        },
                        new
                        {
                            IssueStatusId = 6,
                            IssueStatusName = "Passed Testing"
                        },
                        new
                        {
                            IssueStatusId = 7,
                            IssueStatusName = "Ready To Deploy"
                        },
                        new
                        {
                            IssueStatusId = 8,
                            IssueStatusName = "Deployed"
                        });
                });

            modelBuilder.Entity("taskboard_api.Models.Lane", b =>
                {
                    b.Property<int>("LaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaneId"));

                    b.Property<string>("LaneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaneId");

                    b.ToTable("Lanes");

                    b.HasData(
                        new
                        {
                            LaneId = 1,
                            LaneName = "To Do"
                        },
                        new
                        {
                            LaneId = 2,
                            LaneName = "In Progress"
                        },
                        new
                        {
                            LaneId = 3,
                            LaneName = "Testing"
                        },
                        new
                        {
                            LaneId = 4,
                            LaneName = "Complete"
                        });
                });

            modelBuilder.Entity("taskboard_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("taskboard_api.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<string>("UserRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleId = 1,
                            UserRoleName = "Developer"
                        },
                        new
                        {
                            UserRoleId = 2,
                            UserRoleName = "Business User"
                        },
                        new
                        {
                            UserRoleId = 3,
                            UserRoleName = "Product Manager"
                        },
                        new
                        {
                            UserRoleId = 4,
                            UserRoleName = "Admin"
                        });
                });

            modelBuilder.Entity("taskboard_api.Models.Issue", b =>
                {
                    b.HasOne("taskboard_api.Models.User", "AssignedTo")
                        .WithMany("AssignedIssues")
                        .HasForeignKey("AssignedToId");

                    b.HasOne("taskboard_api.Models.Lane", "CurrentLane")
                        .WithMany("IssuesInLane")
                        .HasForeignKey("CurrentLaneId");

                    b.HasOne("taskboard_api.Models.IssueStatus", "Status")
                        .WithMany()
                        .HasForeignKey("IssueStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("taskboard_api.Models.User", "SubmittedBy")
                        .WithMany("IssuesSubmitted")
                        .HasForeignKey("SubmittedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("CurrentLane");

                    b.Navigation("Status");

                    b.Navigation("SubmittedBy");
                });

            modelBuilder.Entity("taskboard_api.Models.User", b =>
                {
                    b.HasOne("taskboard_api.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("taskboard_api.Models.Lane", b =>
                {
                    b.Navigation("IssuesInLane");
                });

            modelBuilder.Entity("taskboard_api.Models.User", b =>
                {
                    b.Navigation("AssignedIssues");

                    b.Navigation("IssuesSubmitted");
                });
#pragma warning restore 612, 618
        }
    }
}
