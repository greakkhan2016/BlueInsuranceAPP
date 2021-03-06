﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Exceptions;
using Persistence.Extensions;
using Persistence.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Persistence
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(DataContext context) : base(context){}

        /// <summary>
        /// Gets Course Information
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Course</returns>
        public Course GetCourseInformation(int courseId)
        {
            return _context
                .Courses
                .FirstOrDefault(c => c.CourseId == courseId);
        }

        /// <summary>
        /// Gets all courses that have space avaiabale
        /// </summary>
        /// <returns>Avalaible Courses</returns>
        public CoursesAvailableCountRequest GetCoursesAvailableCount()
        { 
            var result = EfCoreExtentions
                .Execute_SingleValue_SP_ReturnInt(_context, "GetAvailableCoursesCount");

            return new CoursesAvailableCountRequest
            {
                Count = result
            };
        }

        public List<RegisterStudentsAttendingCourseRequest> GetStudentsAttendingCourse(int id)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "StudentListForEachCourse";
                
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@CourseId",
                    SqlDbType = SqlDbType.TinyInt,
                    Direction = ParameterDirection.Input,
                    Value = id
                };

                command.Parameters.Add(parameter);
                command.CommandType = CommandType.StoredProcedure;
                _context.Database.OpenConnection();

                var StudentsAttendingCourseData = new List<RegisterStudentsAttendingCourseRequest>();
                
                using (var result = command.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            var data = new RegisterStudentsAttendingCourseRequest
                            {
                                CourseCode = (string)result[1],
                                FirstName = (string)result[12],
                                LastName = (string)result[13],
                                CourseName = (string)result[2]
                            };
                            StudentsAttendingCourseData.Add(data);
                        }
                    }

                    return StudentsAttendingCourseData;
                }
            }
        }

        /// <summary>
        /// Save student registeration for the course
        /// </summary>
        /// <param name="course"></param>
        /// <param name="registerStudent"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> SaveRegisterationOfStudentForCourse(Course course, RegisterStudentForCourseRequest registerStudent, Student student)
        {
            var enrollment = new Enrollment
            {
                CourseId = registerStudent.CourseId,
                StudentId = registerStudent.StudentId
            };

            await IncrementCourseCountAsync(course);
            await IncrementStudentSubjectCount(student);

            _context.Enrollments.Add(enrollment);
            var success = await _context.SaveChangesAsync() > 0;

            return success;
        }

        /// <summary>
        /// Increments student number count for amount of subjects studying
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private async Task IncrementStudentSubjectCount(Student student)
        {
            student.SubjectCount += 1;
            _context.Student.Update(student);

            var success = await _context.SaveChangesAsync() > 0;

            if (!success)
            {
                throw new StudentCourseRegistrationException("Could not Increment Student Subject Count");
            }
        }

        /// <summary>
        /// Increments the course encrollment count
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        private async Task IncrementCourseCountAsync(Course course)
        {
             course.Enrolled += 1;
            _context.Courses.Update(course);

            var success = await _context.SaveChangesAsync() > 0;

            if (!success)
            {
                throw new StudentCourseRegistrationException("Could not Increment Course Count");
            }
        }
    }
}
