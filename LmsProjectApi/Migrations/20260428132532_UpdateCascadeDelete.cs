using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLevels_Subjects_SubjectId",
                table: "SubjectLevels");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLevels_Subjects_SubjectId",
                table: "SubjectLevels",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectLevels_Subjects_SubjectId",
                table: "SubjectLevels");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectLevels_Subjects_SubjectId",
                table: "SubjectLevels",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
