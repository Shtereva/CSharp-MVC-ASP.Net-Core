namespace BookLibray.Models
{
    public class BookHistory
    {
        public int HistoryId { get; set; }
        public History History { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
