﻿namespace BookLibrary.Web.Models
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string ShortDescription { get; set; }

        public string Status { get; set; }
        public string CoverImg { get; set; }
    }
}
