using Newtonsoft.Json;
using Persistence.Exceptions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xunit;

namespace Integration.Tests
{
    public class CourseControllerTests : IntegrationTest
    {
        [Fact]
        public async Task POST_ReturnsTrue_WhenStudentRegistrationIsSuccessful()
        {
            //Arrange
            var request = new RegisterStudentForCourseRequest
            {
                StudentId = 1,
                CourseId = 5,
            };

            var requestJson = JsonConvert.SerializeObject(request);
            var body = new StringContent(requestJson,Encoding.UTF8, "application/json");

            //Act
            var response = await TestClient.PostAsync("/api/course", body);

            //Assert
            Assert.True(response.IsSuccessStatusCode, response.ReasonPhrase);

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultString);
            Assert.True(result);
        }

        [Fact]
        public async Task POST_returns_student_Not_found_exception_whenStudent_doesnotExistForRegistrationUnSuccessful()
        {
            //Arrange
            var request = new RegisterStudentForCourseRequest
            {
                StudentId = 100,
                CourseId = 1
            };

            var requestJson = JsonConvert.SerializeObject(request);
            var body = new StringContent(requestJson, Encoding.UTF8, "application/json");

            //Act
            var response = await TestClient.PostAsync("/api/course", body);

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StudentCourseRegistrationException>(resultString);
            Assert.Equal("Student Not Found", result.Message);
        }

        [Fact]
        public async Task POST_ReturnsError_WhenStudentDoesnotExistForRegistrationUnSuccessful()
        {
            //Arrange
            var request = new RegisterStudentForCourseRequest
            {
                StudentId = 1,
                CourseId = 100
            };

            var requestJson = JsonConvert.SerializeObject(request);
            var body = new StringContent(requestJson, Encoding.UTF8, "application/json");

            //Act
            var response = await TestClient.PostAsync("/api/course", body);

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StudentCourseRegistrationException>(resultString);
            Assert.Equal("Course Not Found", result.Message);
        }
    }
}

