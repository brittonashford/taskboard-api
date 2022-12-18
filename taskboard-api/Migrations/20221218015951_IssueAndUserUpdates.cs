using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace taskboardapi.Migrations
{
    /// <inheritdoc />
    public partial class IssueAndUserUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_UserId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Issues",
                newName: "SubmittedById");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                newName: "IX_Issues_SubmittedById");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AssignedToId",
                table: "Issues",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_AssignedToId",
                table: "Issues",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_SubmittedById",
                table: "Issues",
                column: "SubmittedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_AssignedToId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_SubmittedById",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AssignedToId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "SubmittedById",
                table: "Issues",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_SubmittedById",
                table: "Issues",
                newName: "IX_Issues_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_UserId",
                table: "Issues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
