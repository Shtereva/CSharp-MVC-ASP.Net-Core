namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class CustomersController : Controller
    {
        private readonly CarDealerDbContext db;

        public CustomersController(CarDealerDbContext db)
        {
            this.db = db;
        }

        public List<AllCustomersViewModel> Customers { get; set; }
        public IActionResult All(string order)
        {
            var customersQuery = this.db.Customers
                .AsQueryable();

            if (order == "ascending")
            {
                customersQuery = customersQuery
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver == false);
            }

            else
            {
                customersQuery = customersQuery
                    .OrderByDescending(c => c.BirthDate)
                    .ThenByDescending(c => c.IsYoungDriver == false);
            }

            this.Customers = customersQuery
                .Select(c => new AllCustomersViewModel()
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            return this.View(this.Customers);
        }
    }
}
