namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CourseInstance
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LecturerId { get; set; }
        public User Lecturer { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<StudentCourse> Students { get; set; } = new List<StudentCourse>();

        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
    }
}
