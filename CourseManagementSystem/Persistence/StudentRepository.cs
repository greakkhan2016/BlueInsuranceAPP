using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Extensions;
using Persistence.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Persistence
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context){}

        public StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount()
        {
            var result = EfCoreExtentions.Execute_SingleValue_SP_ReturnInt(_context, "DidNotRegisterMaxCourseAmount");

            return new StudentDidNotRegisterMaxAmountRequest 
            { 
                Count = result 
            };
        }

        public async Task<Student> GetStudentInformationAsync(int StudentId)
        {
            var student = await _context
                 .Student
                 .Include(c => c.Enrollments)
                 .FirstOrDefaultAsync(s => s.Id == StudentId);

            return student;
        }
    }
}
