namespace BookLibray.Models
{
    public class MovieHistory
    {
        public int HistoryId { get; set; }
        public History History { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
