using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Extensions;
using Persistence.Interfaces;
using System.Threading.Tasks;
using ViewModel;

namespace Persistence
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context){}

        /// <summary>
        /// Query for seeing how many students did not register for
        /// max amount of courses
        /// </summary>
        /// <returns></returns>
        public StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount()
        {
            var result = EfCoreExtentions.Execute_SingleValue_SP_ReturnInt(_context, "DidNotRegisterMaxCourseAmount");

            return new StudentDidNotRegisterMaxAmountRequest 
            { 
                Count = result 
            };
        }

        /// <summary>
        /// Gets Single Student Information
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns>Student</returns>
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
