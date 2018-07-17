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

        public BorrowModel(BookLibraryDbContext db)
        {
            this.db = db;
            this.BorrowersNames = this.db.Borrowers.Select(b => b.Name).ToArray();
        }

        public IActionResult OnGet(int bookId)
        {
            if (bookId == 0 || this.db.Books.Find(bookId).Status == "Borrowed")
            {
                return this.RedirectToPage("/Index");
            }

            return this.Page();
        }
        public IActionResult OnPost(int bookId)
        {
            if (this.BorrowBookModel.EndDate != null && this.BorrowBookModel.StartDate > this.BorrowBookModel.EndDate)
            {
                return this.Page();
            }

            var borrower = this.db.Borrowers
                .Where(b => b.Name == this.BorrowBookModel.Name)
                .Include(b => b.Books)
                .FirstOrDefault();

            if (borrower == null)
            {
                return this.Page();
            }


            if (!this.ModelState.IsValid )
            {
                return this.Page();
            }

            borrower.Books.Add(new BooksBorrower(){ BookId = bookId});

            var book = this.db.Books.Find(bookId);

            book.Status = "Borrowed";

            book.History.Add(new BookHistory()
            {
                BookId = bookId,
                History = new History()
                {
                    StartDate = this.BorrowBookModel.StartDate,
                    EndDate = this.BorrowBookModel.EndDate
                }
            });

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult OnGetReturn(int bookId)
        {
            var book = this.db.Books.Find(bookId);

            if (book == null || book.Status == "At Home")
            {
                return this.RedirectToPage("/Index");
            }

            var borrower = this.db.Borrowers
                .Include(b => b.Books)
                .FirstOrDefault(b => b.Books.FirstOrDefault(bo => bo.BookId == bookId) != null);

            if (borrower == null)
            {
                return this.RedirectToPage("/Index");
            }

            var borrowerBook = borrower.Books.FirstOrDefault(b => b.BookId == bookId);

            borrower.Books.Remove(borrowerBook);

            book.Status = "At Home";

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}