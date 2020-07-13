using Persistence.Interfaces;
using Service.Interfaces;
using System;
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

        public StudentDidNotRegisterMaxAmountRequest DidNotRegisterMaxCourseAmount()
        {
            var result = _studentRepository.DidNotRegisterMaxCourseAmount();
            return result;
        }
    }
}
