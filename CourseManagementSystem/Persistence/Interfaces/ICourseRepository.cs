using Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Persistence.Interfaces
{
    public interface ICourseRepository
    {
        CoursesAvailableCountRequest GetCoursesAvailableCount();
        List<RegisterStudentsAttendingCourseRequest> GetStudentsAttendingCourse(int id);
        Course GetCourseInformation(int courseId);

        Task<bool> SaveRegisterationOfStudentForCourse(Course course, RegisterStudentForCourseRequest registerStudent, Student student);
    }
}
