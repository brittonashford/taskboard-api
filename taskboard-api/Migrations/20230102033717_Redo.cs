using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace taskboardapi.Migrations
{
    /// <inheritdoc />
    public partial class Redo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableStatuses",
                columns: table => new
                {
                    AvailableStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaneId = table.Column<int>(type: "int", nullable: false),
                    IssueStatusId = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableStatuses", x => x.AvailableStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CurrentLaneId = table.Column<int>(type: "int", nullable: true),
                    IssueStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedById = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedById = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueId);
                });

            migrationBuilder.CreateTable(
                name: "IssueStatuses",
                columns: table => new
                {
                    IssueStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatuses", x => x.IssueStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Lanes",
                columns: table => new
                {
                    LaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaneName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanes", x => x.LaneId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AvailableStatuses",
                columns: new[] { "AvailableStatusId", "IssueStatusId", "LaneId", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 1, 1, 4 },
                    { 5, 2, 1, 1 },
                    { 6, 2, 1, 2 },
                    { 7, 2, 1, 3 },
                    { 8, 2, 1, 4 },
                    { 9, 3, 2, 1 },
                    { 10, 3, 2, 3 },
                    { 11, 3, 2, 4 },
                    { 12, 4, 3, 1 },
                    { 13, 4, 3, 3 },
                    { 14, 4, 3, 4 },
                    { 15, 5, 3, 2 },
                    { 16, 5, 3, 3 },
                    { 17, 5, 3, 4 },
                    { 18, 6, 3, 2 },
                    { 19, 6, 3, 3 },
                    { 20, 6, 3, 4 },
                    { 21, 7, 4, 1 },
                    { 22, 7, 4, 3 },
                    { 23, 7, 4, 4 },
                    { 24, 8, 4, 1 },
                    { 25, 8, 4, 3 },
                    { 26, 8, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "IssueStatuses",
                columns: new[] { "IssueStatusId", "IssueStatusName" },
                values: new object[,]
                {
                    { 1, "Not Started" },
                    { 2, "Information Needed" },
                    { 3, "Development" },
                    { 4, "Ready To Test" },
                    { 5, "Failed Testing" },
                    { 6, "Passed Testing" },
                    { 7, "Ready To Deploy" },
                    { 8, "Deployed" }
                });

            migrationBuilder.InsertData(
                table: "Lanes",
                columns: new[] { "LaneId", "LaneName" },
                values: new object[,]
                {
                    { 1, "To Do" },
                    { 2, "In Progress" },
                    { 3, "Testing" },
                    { 4, "Complete" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRoleName" },
                values: new object[,]
                {
                    { 1, "Developer" },
                    { 2, "Business User" },
                    { 3, "Product Manager" },
                    { 4, "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableStatuses");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "IssueStatuses");

            migrationBuilder.DropTable(
                name: "Lanes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
