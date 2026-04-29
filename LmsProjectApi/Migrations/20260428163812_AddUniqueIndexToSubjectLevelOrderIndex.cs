using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToSubjectLevelOrderIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SubjectLevels_SubjectId_OrderIndex",
                table: "SubjectLevels",
                columns: new[] { "SubjectId", "OrderIndex" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubjectLevels_SubjectId_OrderIndex",
                table: "SubjectLevels");
        }
    }
}
