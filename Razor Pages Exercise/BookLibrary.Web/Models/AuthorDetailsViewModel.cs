namespace BookLibrary.Web.Models
{
    using System.Collections.Generic;

    public class AuthorDetailsViewModel
    {
        public string AuthorName { get; set; }

        public List<AuthorBooksViewModel> Books { get; set; }
    }
}
