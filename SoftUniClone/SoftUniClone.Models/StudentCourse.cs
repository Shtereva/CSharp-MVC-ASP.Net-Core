namespace SoftUniClone.Models
{
    public class StudentCourse
    {
        public string StudentId { get; set; }
        public User Student { get; set; }

        public int CourseId { get; set; }
        public CourseInstance Course { get; set; }
    }
}
