namespace SoftUniClone.Web.Areas.Admin.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class BaseController : Controller
    {
        public SoftUniCloneDbContext db { get; set; }

        public BaseController(SoftUniCloneDbContext db)
        {
            this.db = db;
        }
    }
}