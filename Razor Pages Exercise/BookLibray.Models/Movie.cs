namespace BookLibray.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string ShortDescription { get; set; }

        public string Status { get; set; } = "At Home";
        public string CoverImg { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<MovieHistory> History { get; set; } = new List<MovieHistory>();

        public ICollection<MovieBorrower> Borrowers { get; set; } = new List<MovieBorrower>();
    }
}
