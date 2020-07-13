using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        /// <summary>
        /// Checks how students have not registered from the full
        /// amount of courses
        /// </summary>
        /// <returns>Amount of students who have registered for full amount of courses</returns>
        [HttpGet(Name = nameof(DidNotRegisterMaxCourseAmount))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult DidNotRegisterMaxCourseAmount()
        {
            var result = _studentService.DidNotRegisterMaxCourseAmount();
            return Ok(result);
        }
    }
}
