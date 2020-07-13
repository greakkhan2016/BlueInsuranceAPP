using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Persistence.Entities
{
    public class Student
    { 
        [Required]
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [MaxLength(100)]
        public string SurName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        [MaxLength(150)]
        public string Address1 { get; set; }
        
        [AllowNull]
        [MaxLength(150)]
        public string Address2 { get; set; }
        
        [AllowNull]
        [MaxLength(150)]
        public string Address3 { get; set; }
        
        [MaxLength(150)]
        public int SubjectCount { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
