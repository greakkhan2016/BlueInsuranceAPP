using FluentValidation;

namespace ViewModel
{
    public class RegisterStudentForCourseRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    public class RegisterStudentForCourseRequestValidator : AbstractValidator<RegisterStudentForCourseRequest>
    {
        public RegisterStudentForCourseRequestValidator()
        {
            RuleFor(x => x.StudentId)
            .NotNull()
            .GreaterThan(0);
            RuleFor(x => x.CourseId)
            .NotNull()
            .GreaterThan(0);
        }
    }
}
