using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }  //change this to id 
        
        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string TeacherName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        public int Enrolled { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
