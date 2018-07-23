using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using BookLibray.Models;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MoviesController : Controller
    {
        private readonly BookLibraryDbContext db;

        public BookDetailsViewModel BookDetails { get; set; }

        public List<AllBooksViewModel> AllMovies { get; set; }

        public List<BorrowBookBindingModel> BorrowBookModel { get; set; }
        public MoviesController(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            this.AllMovies = this.db.Movies
                .Select(b => new AllBooksViewModel()
                {
                    BookId = b.Id,
                    AuthorId = b.DirectorId,
                    Title = b.Title,
                    Author = b.Director.Name,
                    Status = b.Status
                })
                .ToList();

            return this.View(this.AllMovies);
        }
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            Director director = this.db.Directors.FirstOrDefault(a => a.Name == model.Director);

            if (director == null)
            {
                director = new Director() { Name = model.Director };
                this.db.Add(director);
                this.db.SaveChanges();
            }

            var movie = new Movie()
            {
                DirectorId = director.Id,
                CoverImg = model.CoverImg,
                Title = model.Title,
                ShortDescription = model.ShortDescription
            };

            this.db.Add(movie);
            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult Details(int id)
        {
            this.BookDetails = this.db.Movies
                .Where(m => m.Id == id)
                .Select(m => new BookDetailsViewModel()
                {
                    Id = id,
                    Author = m.Director.Name,
                    CoverImg = m.CoverImg,
                    Title = m.Title,
                    ShortDescription = m.ShortDescription,
                    Status = m.Status
                })
                .FirstOrDefault();

            if (this.BookDetails == null)
            {
                return this.NotFound();
            }


            return this.View(this.BookDetails);
        }

        public IActionResult Borrow(int id)
        {
            if (id == 0 || this.db.Movies.Find(id).Status == "Borrowed")
            {
                return this.RedirectToPage("/Index");
            }

            this.ViewBag.Names = this.db.Borrowers.Select(b => b.Name).ToArray();

            return this.View();
        }

        [HttpPost]
        public IActionResult Borrow(BorrowBookBindingModel model)
        {
            var borrower = this.db.Borrowers
                .Where(b => b.Name == model.Name)
                .Include(b => b.Movies)
                .FirstOrDefault();

            if (borrower == null)
            {
                return this.View();
            }


            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            borrower.Movies.Add(new MovieBorrower() { MovieId = model.Id });

            var movie = this.db.Movies.Find(model.Id);

            movie.Status = "Borrowed";

            movie.History.Add(new MovieHistory()
            {
                MovieId = model.Id,
                History = new History()
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                }
            });

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult Return(int id)
        {
            var movie = this.db.Movies
                .Include(m => m.History)
                .ThenInclude(h => h.History)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null || movie.Status == "At Home")
            {
                return this.RedirectToPage("/Index");
            }

            var borrower = this.db.Borrowers
                .Include(b => b.Movies)
                .FirstOrDefault(b => b.Movies.FirstOrDefault(m => m.MovieId == id) != null);

            if (borrower == null)
            {
                return this.RedirectToPage("/Index");
            }

            var borrowerMovie = borrower.Movies
                .FirstOrDefault(b => b.MovieId == id);

            borrower.Movies.Remove(borrowerMovie);

            movie.Status = "At Home";
            movie.History.Last().History.EndDate = DateTime.Today;

            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }

        public IActionResult Status(int id)
        {
            var movie = this.db.Movies
                .Where(m => m.Id == id)
                .Select(m => new
                {
                    m.Title,
                    History = m.History.Select(h => h.History).ToList()
                }).FirstOrDefault();

            if (movie == null)
            {
                return this.RedirectToPage("/Index");
            }

            this.BorrowBookModel = movie.History
                .Select(h => new BorrowBookBindingModel()
                {
                    Name = movie.Title,
                    StartDate = h.StartDate,
                    EndDate = h.EndDate
                })
                .ToList();

            return this.View(this.BorrowBookModel);
        }
    }
}