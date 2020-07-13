using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Interfaces
{
    public interface ICourseService
    {
        CoursesAvailableCountRequest CoursesAvailableCount();
        List<RegisterStudentsAttendingCourseRequest> ListStudentsAttendingCourse(int id);
        Task<bool> RegisterStudentForCourseAsync(RegisterStudentForCourseRequest registerStudent);
        
    }
}
