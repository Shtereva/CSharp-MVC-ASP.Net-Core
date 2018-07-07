namespace FDMC.App.Controllers
{
    using System.Linq;
    using BindingModels;
    using Data;
    using FDMC.Models;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class CatsController : Controller
    {
        private readonly CatsDbContext context;

        public CatsController(CatsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCatBindingModel model)
        {
            var cat = new Cat()
            {
                Name = model.Name,
                Age = model.Age,
                Breed = model.Breed,
                ImageUrl = model.ImageUrl
            };

            this.context.Add(cat);
            this.context.SaveChanges();

            return this.Redirect("/");
        }

        public IActionResult Details(int id)
        {
            var cat = this.context.Cats
                .Where(c => c.Id == id)
                .Select(c => new CatViewModel()
                {
                    Name = c.Name,
                    Age = c.Age,
                    Breed = c.Breed,
                    ImageUrl = c.ImageUrl
                })
                .FirstOrDefault();

            if (cat == null)
            {
                return this.Redirect("/");
            }
            return this.View(cat);
        }
    }
}
