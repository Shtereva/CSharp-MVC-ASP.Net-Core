namespace SoftUniClone.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

        public ResourceType Type { get; set; }

        [DataType(DataType.Url)]
        public string ResourceUrl { get; set; }

        public int Order { get; set; }
    }
}
