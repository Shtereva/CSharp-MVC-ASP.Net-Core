namespace BookLibrary.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AllBooksViewModel
    {
        [Required]

        public int BookId { get; set; }

        [Required]

        public int AuthorId { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        public string Status { get; set; }
    }
}
