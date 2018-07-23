namespace BookLibrary.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Models;

    public class SearchModel : PageModel
    {
        private BookLibraryDbContext db;

        public string SearchTerm { get; set; }
        public List<SearchBookViewModel> Books { get; set; }

        public List<SearchAuthorViewModel> Authors { get; set; }

        public List<SearchDirectorViewModel> Directors { get; set; }

        public List<SearchMovieViewModel> Movies { get; set; }

        public SearchModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public IActionResult OnGet(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return this.RedirectToPage("/Index");
            }
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

            this.Movies = this.db.Movies
                .Where(m => m.Title.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(m => new SearchMovieViewModel()
                {
                    MovieId = m.Id,
                    Title = m.Title
                })
                .ToList();

            this.Directors = this.db.Movies
                .Where(d => d.Director.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(d => new SearchDirectorViewModel()
                {
                    DirectorId = d.DirectorId,
                    Name = d.Director.Name
                })
                .ToList();

            return this.Page();
        }
    }
}