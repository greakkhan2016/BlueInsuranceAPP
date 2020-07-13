using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Enrollment
    {
        [Required]
        public int EnrollmentId { get; set; }
        
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
