using Moq;
using Persistence.Entities;
using Persistence.Exceptions;
using Persistence.Interfaces;
using Persistence.Migrations;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;
using Xunit;

namespace UnitTests
{
    public class CourseServiceTests
    {
        [Fact]
        public async Task RegisterStudentForCourseAsync_returns_ok_successfully_registered()
        {
            //Arrange
            var _courseRepository = new Mock<ICourseRepository>();
            var _studentRepository = new Mock<IStudentRepository>();

            var testStudent = new Student
            {
                Id = 2,
                SubjectCount = 4,
                Enrollments = new List<Enrollment>
                {
                   new Enrollment{CourseId =3}
                }
            };

            var testCourse = new Course
            {
                CourseId = 1,
                Capacity = 20,
                Enrolled = 18,
            };

            var request = new RegisterStudentForCourseRequest
            {
                CourseId = testCourse.CourseId,
                StudentId = testStudent.Id
            };

            _studentRepository.Setup(s => s.GetStudentInformationAsync(testStudent.Id)).Returns(Task.FromResult(testStudent));
            _courseRepository.Setup(c => c.GetCourseInformation(testCourse.CourseId)).Returns(testCourse);
            _courseRepository.Setup(c => c.SaveRegisterationOfStudentForCourse(testCourse, request, testStudent)).Returns(Task.FromResult(true));            

            var sut = new CourseService(_courseRepository.Object, _studentRepository.Object);
            
            //Act
            var response = await sut.RegisterStudentForCourseAsync(request);
            //Assert
            Assert.True(response, "Register Student Returned False");
        }

        [Fact]
        public async Task RegisterStudentForCourseAsync_returns_message_noStudentfound()
        {
            //Arrange
            var _courseRepository = new Mock<ICourseRepository>();
            var _studentRepository = new Mock<IStudentRepository>();

            var testStudent = new Student
            {
                Id = 2,
                SubjectCount = 4,
            };

            var testCourse = new Course
            {
                CourseId = 1,
                Capacity = 20,
                Enrolled = 18,
            };

            var request = new RegisterStudentForCourseRequest
            {
                CourseId = testCourse.CourseId,
                StudentId = testStudent.Id
            };

            _studentRepository.Setup(s => s.GetStudentInformationAsync(testStudent.Id)).Returns(Task.FromResult<Student>(null));
            _courseRepository.Setup(c => c.GetCourseInformation(testCourse.CourseId)).Returns(testCourse);
            _courseRepository.Setup(c => c.SaveRegisterationOfStudentForCourse(testCourse, request, testStudent)).Returns(Task.FromResult(true));

            var sut = new CourseService(_courseRepository.Object, _studentRepository.Object);
            //Act and Assert
            var exception = await Assert.ThrowsAsync<StudentCourseRegistrationException>(() => sut.RegisterStudentForCourseAsync(request));

            Assert.Equal("Student Not Found", exception.Message);
        }

        [Fact]
        public async Task RegisterStudentForCourseAsync_returns_message_courseCapacityIsFull()
        {
            //Arrange
            var _courseRepository = new Mock<ICourseRepository>();
            var _studentRepository = new Mock<IStudentRepository>();

            var testStudent = new Student
            {
                Id = 2,
                SubjectCount = 4,
                Enrollments = new List<Enrollment>
                {
                   new Enrollment{CourseId =3}
                }
            };

            var testCourse = new Course
            {
                CourseId = 1,
                Capacity = 20,
                Enrolled = 20,
            };

            var request = new RegisterStudentForCourseRequest
            {
                CourseId = testCourse.CourseId,
                StudentId = testStudent.Id
            };

            _studentRepository.Setup(s => s.GetStudentInformationAsync(testStudent.Id)).Returns(Task.FromResult(testStudent));
            _courseRepository.Setup(c => c.GetCourseInformation(testCourse.CourseId)).Returns(testCourse);
            _courseRepository.Setup(c => c.SaveRegisterationOfStudentForCourse(testCourse, request, testStudent)).Returns(Task.FromResult(true));

            var sut = new CourseService(_courseRepository.Object, _studentRepository.Object);
            //Act and Assert
            var exception = await Assert.ThrowsAsync<StudentCourseRegistrationException>(() => sut.RegisterStudentForCourseAsync(request));

            Assert.Equal("Course is fully Booked", exception.Message);

        }

        [Fact]
        public async Task RegisterStudentForCourseAsync_returns_message_studentIsAlreadyRegisteredForCourse()
        {
            //Arrange
            var _courseRepository = new Mock<ICourseRepository>();
            var _studentRepository = new Mock<IStudentRepository>();

            var testStudent = new Student
            {
                Id = 2,
                SubjectCount = 4,
                Enrollments = new List<Enrollment>
                {
                   new Enrollment{CourseId =1}
                }
            };

            var testCourse = new Course
            {
                CourseId = 1,
                Capacity = 10,
                Enrolled = 20,
            };

            var request = new RegisterStudentForCourseRequest
            {
                CourseId = testCourse.CourseId,
                StudentId = testStudent.Id
            };

            _studentRepository.Setup(s => s.GetStudentInformationAsync(testStudent.Id)).Returns(Task.FromResult(testStudent));
            _courseRepository.Setup(c => c.GetCourseInformation(testCourse.CourseId)).Returns(testCourse);
            _courseRepository.Setup(c => c.SaveRegisterationOfStudentForCourse(testCourse, request, testStudent)).Returns(Task.FromResult(true));

            var sut = new CourseService(_courseRepository.Object, _studentRepository.Object);
            //Act and Assert
            var exception = await Assert.ThrowsAsync<StudentCourseRegistrationException>(() => sut.RegisterStudentForCourseAsync(request));

            Assert.Equal("Student is Already Registered for Course", exception.Message);

        }
    }
}
