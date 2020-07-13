using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class spDidNotRegisterMaxCourseAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[DidNotRegisterMaxCourseAmount]
                AS
                BEGIN
                     SELECT COUNT(student.SubjectCount) FROM Student WHERE Student.SubjectCount < 6;;
                END";

            migrationBuilder.Sql(sp);
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
