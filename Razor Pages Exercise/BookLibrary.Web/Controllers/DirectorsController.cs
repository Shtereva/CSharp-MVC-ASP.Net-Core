namespace BookLibrary.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class DirectorsController : Controller
    {
        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
