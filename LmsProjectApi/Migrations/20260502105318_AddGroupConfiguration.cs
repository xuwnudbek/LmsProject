using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name_CourseId_LevelId",
                table: "Groups",
                columns: new[] { "Name", "CourseId", "LevelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_Name_CourseId_LevelId",
                table: "Groups");
        }
    }
}
