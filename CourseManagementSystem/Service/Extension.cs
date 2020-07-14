using Persistence.Entities;
using Persistence.Exceptions;
using System.Linq;
using ViewModel;

namespace Service
{
    public static class Extensions
    {
        public static T EnsureNotNull<T>(this T t, string message = null)
        {
            if (t == null) 
                throw new StudentCourseRegistrationException(message ?? "Error not found");
            return t;
        }
        public static Student EnsureNotAlreadyRegistered(this Student student, int courseId)
        {
            if (student.Enrollments.Any(x => x.CourseId == courseId)) 
                throw new StudentCourseRegistrationException("Student is Already Registered for Course");
            return student;
        }

        public static Student EnsureStudentHasNotEnrolledMaxAmount(this Student student)
        {
            if (student.SubjectCount >= 5)
            {
                throw new StudentCourseRegistrationException("Cannot Register Amount of Courses");
            }
            return student;
        }

        public static Course EnsureCapacityNotFull(this Course course)
        {
            if (course.Enrolled >= course.Capacity)
            {
                throw new StudentCourseRegistrationException("Course is fully Booked");
            }
            return course;
        }
    }
}