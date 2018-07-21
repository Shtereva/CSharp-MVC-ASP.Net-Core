namespace CarDealer.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class SuppliersController : Controller  
    {
        private readonly CarDealerDbContext db;

        public List<SupplierViewModel> Suppliers { get; set; }
        public SuppliersController(CarDealerDbContext db)
        {
            this.db = db;
        }


        public IActionResult All(string type)
        {
            this.Suppliers = this.db.Suppliers
                .Where(s => type.ToLower() == "local" ? s.IsImporter == false : s.IsImporter)
                .Select(s => new SupplierViewModel()
                {
                    Name = s.Name,
                    Id = s.Id,
                    PartsOffered = s.Parts.Sum(p => p.Quantity)
                })
                .ToList();

            return this.View(this.Suppliers);
        }
    }
}
