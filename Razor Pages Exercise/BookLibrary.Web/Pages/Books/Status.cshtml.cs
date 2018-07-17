using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLibrary.Web.Pages.Books
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Microsoft.AspNetCore.Mvc;

    public class StatusModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public List<BorrowBookBindingModel> BorrowBookModel { get; set; }


        public StatusModel(BookLibraryDbContext db)
        {
            this.db = db;
        }
        public IActionResult OnGet(int bookId)
        {
            var book = this.db.Books
                .Where(b => b.Id == bookId)
                .Select(b => new
                {
                    b.Title,
                    History = b.History.Select(h => h.History).ToList()
                }).FirstOrDefault();

            if (book == null)
            {
                return this.RedirectToPage("/Index");
            }

            this.BorrowBookModel = book.History
                .Select(h => new BorrowBookBindingModel()
                {
                    Name = book.Title,
                    StartDate = h.StartDate,
                    EndDate = h.EndDate
                })
                .ToList();

            return this.Page();
        }
    }
}