namespace BookLibrary.Web.Pages.Authors
{
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Models;

    public class DetailsModel : PageModel
    {
        private BookLibraryDbContext db;
        public DetailsModel(BookLibraryDbContext db)
        {
            this.db = db;
        }
        public AuthorDetailsViewModel AuthorDetails { get; set; }
        public IActionResult OnGet(int id)
        {
            this.AuthorDetails = this.db.Authors
                .Where(a => a.Id == id)
                .Select(a => new AuthorDetailsViewModel()
                {
                    AuthorName = a.Name,
                    Books = a.Books.Select(b => new AuthorBooksViewModel()
                    {
                        Id = b.Id,
                        BookTitle = b.Title,
                        Status = b.Status
                    }).ToList()
                })
                .FirstOrDefault();

            if (this.AuthorDetails == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}