using Microsoft.AspNetCore.Mvc;
using Persistence.Exceptions;
using Service.Communication;
using Service.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using ViewModel;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        }

        /// <summary>
        ///How many courses are avaiable to register for 
        /// </summary>
        /// <returns>Number of courses available</returns>
        [HttpGet(Name = nameof(GetCourseAvailableCount))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult GetCourseAvailableCount()
        {
            var result = _courseService.CoursesAvailableCount();
            return Ok(result);
        }

        /// <summary>
        /// Checks how students have not registered from the full
        /// amount of courses
        /// </summary>
        /// <returns>Amount of students who have registered for full amount of courses</returns>
        [HttpPost(Name = nameof(RegisterStudentForCourse))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> RegisterStudentForCourse([FromBody] RegisterStudentForCourseRequest registerStudent)
        {
            try
            {
                var result = await _courseService.RegisterStudentForCourseAsync(registerStudent);
                return Ok(result);
            }
            catch (StudentCourseRegistrationException cex)
            {
                var response = new Response(cex.Message);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Gets list of students in a course
        /// </summary>
        /// <returns>Returns list of students in a course</returns>
        [HttpGet("{id}", Name = nameof(ListStudentsRegisterForCourse))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public ActionResult ListStudentsRegisterForCourse(int id)
        {
            try
            {
                var result =  _courseService.ListStudentsAttendingCourse(id);
                return Ok(result);
            }
            catch (StudentCourseRegistrationException cex)
            {
                var response = new Response(cex.Message);
                return BadRequest(response);
            }
        }
    }
}


