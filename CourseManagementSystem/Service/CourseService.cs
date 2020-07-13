using Persistence.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseService(ICourseRepository courseRepository,
                             IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        /// <summary>
        /// Get courses that are available to be register for
        /// </summary>
        /// <returns></returns>
        public CoursesAvailableCountRequest CoursesAvailableCount()
        {
            var result = _courseRepository.GetCoursesAvailableCount();
            return result;
        }

        /// <summary>
        /// List of students that are registered for the course
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of students</returns>
        public List<RegisterStudentsAttendingCourseRequest> ListStudentsAttendingCourse(int id)
        {
            var result = _courseRepository.GetStudentsAttendingCourse(id);
            return result;
        }

        /// <summary>
        /// Registers Students for a course
        /// </summary>
        /// <param name="registerStudent"></param>
        /// <returns></returns>
        public async Task<bool> RegisterStudentForCourseAsync(RegisterStudentForCourseRequest registerStudent)
        {
            var student = await _studentRepository.GetStudentInformationAsync(registerStudent.StudentId);

            student
                .EnsureNotNull("Student Not Found")
                .EnsureNotAlreadyRegistered(registerStudent.CourseId)
                .EnsureStudentHasNotEnrolledMaxAmount();

            var course = _courseRepository.GetCourseInformation(registerStudent.CourseId);

            course
                .EnsureNotNull("Course Not Found")
                .EnsureCapacityNotFull();

            return await _courseRepository.SaveRegisterationOfStudentForCourse(course, registerStudent, student);
        }
    }
}
