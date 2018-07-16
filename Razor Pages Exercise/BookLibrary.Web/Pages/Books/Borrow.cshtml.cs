namespace BookLibrary.Web.Pages.Books
{
    using System.Linq;
    using BindingModels;
    using BookLibray.Models;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class BorrowModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        [BindProperty]
        public BorrowBookBindingModel BorrowBookModel { get; set; }

        public string[] BorrowersNames { get; set; }
        public string ErrorMessage { get; set; }

        public BorrowModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public IActionResult OnGet(int bookId)
        {
            if (bookId == 0 || this.db.Books.Find(bookId).Status == "Borrowed")
            {
                return this.RedirectToPage("/Index");
            }

            this.BorrowersNames = this.db.Borrowers.Select(b => b.Name).ToArray();
            return this.Page();
        }
        public IActionResult OnPost(int bookId)
        {
            
            var borrower = this.db.Borrowers
                .Where(b => b.Name == this.BorrowBookModel.Name)
                .Include(b => b.Books)
                .FirstOrDefault();

            this.ViewData["ErrorMessage"] = this.ErrorMessage;

            if (!this.ModelState.IsValid )
            {
                return this.Page();
            }

            if (borrower == null)
            {
                this.ErrorMessage = "No such borrower.";
                return this.Page();
            }

            borrower.Books.Add(new BooksBorrower(){ BookId = bookId});

            var book = this.db.Books.Find(bookId);
            book.Status = "Borrowed";

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult OnGetReturn(int bookId)
        {
            var book = this.db.Books.Find(bookId);

            var borrower = this.db.Borrowers
                .Include(b => b.Books)
                .FirstOrDefault(b => b.Books.FirstOrDefault(bo => bo.BookId == bookId) != null);

            var borrowerBook = borrower.Books.FirstOrDefault(b => b.BookId == bookId);

            borrower.Books.Remove(borrowerBook);

            book.Status = "At Home";

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}