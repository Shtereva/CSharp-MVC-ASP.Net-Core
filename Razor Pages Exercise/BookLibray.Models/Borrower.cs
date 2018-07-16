namespace BookLibray.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public ICollection<BooksBorrower> Books { get; set; } = new List<BooksBorrower>();
    }
}
