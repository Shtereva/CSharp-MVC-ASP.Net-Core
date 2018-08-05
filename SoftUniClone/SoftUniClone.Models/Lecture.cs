namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Lecture
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string LectureHall { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Order { get; set; }

        public int CourseId { get; set; }
        public CourseInstance Course { get; set; }

        public ICollection<Resource> Recourses { get; set; } = new List<Resource>();
    }
}
