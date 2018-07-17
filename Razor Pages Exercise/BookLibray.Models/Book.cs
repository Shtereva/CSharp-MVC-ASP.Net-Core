namespace BookLibray.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
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
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookHistory> History { get; set; } = new List<BookHistory>();

        public ICollection<BooksBorrower> Borrowers { get; set; } = new List<BooksBorrower>();
    }
}
