namespace BookLibrary.Web.Views
{
    using System.Collections.Generic;

    public class AuthorDetailsViewModel
    {
        public string AuthorName { get; set; }

        public List<AuthorBooksViewModel> Books { get; set; }
    }
}
