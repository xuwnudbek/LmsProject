using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEndAtField2LessionSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "LessonSessions");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndAt",
                table: "LessonSessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "LessonSessions");

            migrationBuilder.AddColumn<double>(
                name: "DurationInMinutes",
                table: "LessonSessions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
