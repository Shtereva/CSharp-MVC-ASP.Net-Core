namespace SoftUniClone.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic; 
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        public ICollection<StudentCourse> EnrolledCourses { get; set; } = new List<StudentCourse>();

        public ICollection<CourseInstance> LecturerCourses { get; set; } = new List<CourseInstance>();
    }
}
