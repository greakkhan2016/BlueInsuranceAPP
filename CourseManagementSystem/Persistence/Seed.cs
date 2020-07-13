using Microsoft.EntityFrameworkCore.Internal;
using Persistence.Entities;
using System;
using System.Collections.Generic;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
         {
             if (!context.Student.Any())
             {
                 var students = new List<Student>
                 {
                     new Student
                     {
                         FirstName = "Larry",
                         SurName = "Page",
                         Gender = (Entities.Gender)Gender.Male,
                         DateOfBirth = new DateTime(1987,2,10),
                         Address1 = "35 Broadway"
                     },
                     new Student
                     {
                         FirstName = "Steve",
                         SurName = "Wozniak",
                         Gender = (Entities.Gender)Gender.Male,
                         DateOfBirth = new DateTime(1965,4,10),
                         Address1 = "35 Broadway"
                     },
                     new Student
                     {
                         FirstName = "Mark",
                         SurName = "Zuckerberg",
                         Gender = (Entities.Gender)Gender.Male,
                         DateOfBirth = new DateTime(1945,4,18),
                         Address1 = "85 New Road"
                     },
                     new Student
                     {
                         FirstName = "Larry",
                         SurName = "Ellison",
                         Gender = (Entities.Gender)Gender.Male,
                         DateOfBirth = new DateTime(1995,4,18),
                         Address1 = "9 The Green",
                         Address2="BRISTOL",
                         Address3="BS79 8YR"
                     },
                     new Student
                     {
                         FirstName = "Sergey",
                         SurName = "Brin",
                         Gender = (Entities.Gender)Gender.Male,
                         DateOfBirth = new DateTime(1995,4,18),
                         Address1 = "25 Highfield Road",
                         Address2="COLCHESTER",
                         Address3="CO13 1UF"
                     }
                 };

                 context.Student.AddRange(students);
                 context.SaveChanges();
             }

             if (!context.Courses.Any())
             {
                 var courses = new List<Course>
                 {
                     new Course
                     {
                         CourseCode = "101",
                         CourseName ="Maths",
                         TeacherName = "Mr Bean",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "102",
                         CourseName ="English",
                         TeacherName = "Mr Fylnn",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,10,06),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "103",
                         CourseName ="Irish",
                         TeacherName = "Mr Black",
                         StartDate = new DateTime(2020,02,02),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "104",
                         CourseName ="History",
                         TeacherName = "Ms Sheridan",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "105",
                         CourseName ="Engineering",
                         TeacherName = "Mr Tuck",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "106",
                         CourseName ="French",
                         TeacherName = "Ms Lee",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     },
                     new Course
                     {
                         CourseCode = "107",
                         CourseName ="German",
                         TeacherName = "Mr Aldo",
                         StartDate = new DateTime(2020,07,09),
                         EndDate = new DateTime(2020,09,09),
                         Capacity = 20,
                         Enrolled= 0
                     }
                 };
                 context.Courses.AddRange(courses);
                 context.SaveChanges();
             }

             if (!context.Enrollments.Any())
             {
                 var enrollment = new List<Enrollment> 
                 {
                    new Enrollment
                    {
                        CourseId = 1,
                        StudentId = 1
                    }
                 };
                  context.Enrollments.AddRange(enrollment);
                 context.SaveChanges();

             };
        }  
    }
}


 
 
 
 
