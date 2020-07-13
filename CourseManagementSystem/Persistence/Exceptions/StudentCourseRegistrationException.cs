using System;

namespace Persistence.Exceptions
{
    public class StudentCourseRegistrationException: Exception
    {
        public StudentCourseRegistrationException(string message): base(message)
        {
        }
    }
}
