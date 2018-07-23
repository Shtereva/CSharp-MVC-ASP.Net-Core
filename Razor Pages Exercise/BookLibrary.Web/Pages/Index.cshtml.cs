namespace BookLibrary.Web.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Data;
    using Models;

    public class IndexModel : PageModel
    {
        private readonly BookLibraryDbContext db;
        public List<AllBooksViewModel> AllBooks { get; set; }
        public string Name { get; set; }
        public IndexModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            this.AllBooks = this.db.Books
                .Select(b => new AllBooksViewModel()
                {
                    BookId = b.Id,
                    AuthorId = b.AuthorId,
                    Title = b.Title,
                    Author = b.Author.Name,
                    Status = b.Status
                })
                .ToList();
        }
    }
}
