namespace SoftUniClone.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ResourceType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

    }
}
