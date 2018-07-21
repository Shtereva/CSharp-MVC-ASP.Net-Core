namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CarsController : Controller
    {
        private readonly CarDealerDbContext db;

        public List<AllCarsViewModel> Cars { get; set; }
        public List<PartViewModel> CarParts { get; set; }

        public CarsController(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IActionResult CarsByMake(string make)
        {
            this.Cars = this.db.Cars
                .Where(c => c.Make == make)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new AllCarsViewModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = (c.TravelledDistance / 1000)
                })
                .ToList();

            return this.View(this.Cars);
        }

        public IActionResult Parts(int id)
        {
            var car = this.db.Cars
                .Where(c => c.Id == id)
                .Select(c => c.Parts
                    .Select(p => p.Part)
                    .ToArray())
                .First();

            this.CarParts = car
                .Select(p => new PartViewModel()
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return this.View(this.CarParts);
        }
    }
}
