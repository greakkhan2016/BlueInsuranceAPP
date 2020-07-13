using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class spStudentListForEachCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[StudentListForEachCourse]
                @CourseId SMALLINT
                AS
                BEGIN
                  select * from Courses 
                  inner join Enrollments on Enrollments.CourseId = Courses.CourseId
                  inner join Student on Enrollments.StudentId = Student.Id
                  where Courses.CourseId = @CourseId
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
