﻿using Persistence.Exceptions;
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

        public CoursesAvailableCountRequest CoursesAvailableCount()
        {
            var result = _courseRepository.GetCoursesAvailableCount();
            return result;
        }

        public List<RegisterStudentsAttendingCourseRequest> ListStudentsAttendingCourse(int id)
        {
            var result = _courseRepository.GetStudentsAttendingCourse(id);
            return result;
        }

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
