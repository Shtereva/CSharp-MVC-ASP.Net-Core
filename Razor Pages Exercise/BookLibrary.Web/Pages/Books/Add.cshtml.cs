namespace BookLibrary.Web.Pages.Books
{
    using BindingModels;
    using BookLibray.Models;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;

    public class AddModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        [BindProperty]
        public AddBookBindingModel BookModel { get; set; }

        public AddModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            Author author = this.db.Authors.FirstOrDefault(a => a.Name == this.BookModel.Author);

            if (author == null)
            {
                author = new Author() { Name = this.BookModel.Author };
                this.db.Add(author);
                this.db.SaveChanges();
            }

            var book = new Book()
            {
                AuthorId = author.Id,
                CoverImg = this.BookModel.CoverImg,
                Title = this.BookModel.Title,
                ShortDescription = this.BookModel.ShortDescription
            };

            this.db.Add(book);
            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}