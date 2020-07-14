using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Interfaces
{
    public interface IStudentService
    {
        StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount();
        Task<IEnumerable<AllStudentsRecordRequest>> GetAllStudentInSystem();
    }
}
