namespace BookLibrary.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Views;

    public class SearchModel : PageModel
    {
        private BookLibraryDbContext db;

        public string SearchTerm { get; set; }
        public List<SearchBookViewModel> Books { get; set; }

        public List<SearchAuthorViewModel> Authors { get; set; }

        public SearchModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public void OnGet(string searchTerm)
        {
            this.SearchTerm = searchTerm;

            this.Books = this.db.Books
                .Where(b => b.Title.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => new SearchBookViewModel()
                {
                    BookId = b.Id,
                    Title = b.Title
                })
                .ToList();

            this.Authors = this.db.Books
                .Where(b => b.Author.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => new SearchAuthorViewModel()
                {
                    AuthorId = b.AuthorId,
                    Name = b.Author.Name
                })
                .ToList();
        }
    }
}