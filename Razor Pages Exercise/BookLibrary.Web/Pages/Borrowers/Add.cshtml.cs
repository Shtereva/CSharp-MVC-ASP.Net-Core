namespace BookLibrary.Web.Pages.Borrowers
{
    using System.Linq;
    using BindingModels;
    using BookLibray.Models;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class AddModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        [BindProperty]
        public AddBorrowerBindingModel BorrowerModel { get; set; }
        public AddModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid || this.db.Borrowers.Any(b => b.Name == this.BorrowerModel.Name))
            {
                return this.Page();
            }

            var borrower = new Borrower()
            {
                Name = this.BorrowerModel.Name,
                Address = this.BorrowerModel.Address
            };

            this.db.Add(borrower);
            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}