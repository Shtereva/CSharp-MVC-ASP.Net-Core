namespace SoftUniClone.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        public ICollection<StudentCourse> EnrolledCourses { get; set; } = new List<StudentCourse>();

        public ICollection<CourseInstance> LecturerCourses { get; set; } = new List<CourseInstance>();
    }
}
