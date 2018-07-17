namespace BookLibray.Models
{
    using System;
    using System.Collections.Generic;

    public class History
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime? EndDate { get; set; }

        public ICollection<BookHistory> Books { get; set; } = new List<BookHistory>();
    }
}
