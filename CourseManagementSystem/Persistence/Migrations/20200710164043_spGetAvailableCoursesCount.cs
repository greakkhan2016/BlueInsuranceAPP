using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class spGetAvailableCoursesCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetAvailableCoursesCount]
                AS
                BEGIN
                    SELECT COUNT(courses.Enrolled) FROM Courses WHERE Courses.Capacity > Courses.Enrolled;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
