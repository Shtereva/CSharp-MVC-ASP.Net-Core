namespace SoftUniClone.Models
{
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }
        public ICollection<CourseInstance> CourseInstances { get; set; } = new List<CourseInstance>();
    }
}
