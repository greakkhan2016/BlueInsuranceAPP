using Persistence.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository)); 
        }

        /// <summary>
        /// Gets student number that did not register for the max amount of courses
        /// </summary>
        /// <returns></returns>
        public StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount()
        {
            var result = _studentRepository.DidNotRegisterMaxCourseAmount();
            return result;
        }

        public async Task<IEnumerable<AllStudentsRecordRequest>> GetAllStudentInSystem()
        {
            var result = await _studentRepository.GetAllStudents();
            return result;
        }
    }
}
