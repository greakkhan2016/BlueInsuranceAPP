using Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Persistence.Interfaces
{
    public interface IStudentRepository
    {
        StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount();
        Task<Student> GetStudentInformationAsync(int StudentId);
        Task<IEnumerable<AllStudentsRecordRequest>> GetAllStudents();
    }
}
