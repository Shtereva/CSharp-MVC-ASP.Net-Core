namespace BookLibray.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Director
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
