using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LmsProjectApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateAtTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Trigger function yaratish
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION update_updatedat_column()
                RETURNS TRIGGER AS $$
                BEGIN
                    NEW.""UpdatedAt"" = CURRENT_TIMESTAMP;
                    RETURN NEW;
                END;
                $$ language 'plpgsql';
            ");

            // 2. Har bir jadval uchun trigger yaratish
            migrationBuilder.Sql(@"CREATE TRIGGER update_groups_updatedat
                BEFORE UPDATE ON ""Groups""
                FOR EACH ROW EXECUTE FUNCTION update_updatedat_column();");

            migrationBuilder.Sql(@"CREATE TRIGGER update_courses_updatedat
                BEFORE UPDATE ON ""Courses""
                FOR EACH ROW EXECUTE FUNCTION update_updatedat_column();");

            // boshqa jadvallar uchun ham shu pattern...
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS update_groups_updatedat ON ""Groups"";");
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS update_courses_updatedat ON ""Courses"";");
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS update_updatedat_column();");
        }
    }
}
