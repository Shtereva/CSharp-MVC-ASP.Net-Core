namespace FDMC.App.Controllers
{
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class HomeController : Controller
    {
        private readonly CatsDbContext catsDbContext;

        public HomeController(CatsDbContext catsDbContext)
        {
            this.catsDbContext = catsDbContext;
        }

        public IActionResult Index()
        {
            var cats = this.catsDbContext.Cats
                .Select(c => new CatNameViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return this.View(cats);
        }
    }
}
