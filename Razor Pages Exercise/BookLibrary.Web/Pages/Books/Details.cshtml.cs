namespace BookLibrary.Web.Pages.Books
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

        public BookDetailsViewModel BookDetails { get; set; }
        public IActionResult OnGet(int id)
        {
            this.BookDetails = this.db.Books
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsViewModel()
                {
                    Author = b.Author.Name,
                    CoverImg = b.CoverImg,
                    Title = b.Title,
                    ShortDescription = b.ShortDescription,
                    Status = b.Status
                })
                .FirstOrDefault();

            if (this.BookDetails == null)
            {
                return this.NotFound();
            }

            return this.Page();
        }
    }
}