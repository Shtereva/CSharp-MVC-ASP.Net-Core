namespace SoftUniClone.Web.Areas.Admin.Controllers.Home
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

   
    public class HomeController : BaseController
    {
        public HomeController(SoftUniCloneDbContext db) : base(db)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}