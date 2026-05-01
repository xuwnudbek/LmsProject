using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId_Name",
                table: "Courses",
                columns: new[] { "UserId", "Name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId_Name",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");
        }
    }
}
