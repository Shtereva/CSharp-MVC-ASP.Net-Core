namespace BookLibray.Models
{
    public class MovieBorrower
    {
        public int MovieId { get; set; }
        public Movie Movie  { get; set; }

        public int BorrowerId { get; set; }
        public Borrower Borrower  { get; set; }
    }
}
