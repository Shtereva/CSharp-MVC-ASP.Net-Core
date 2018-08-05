namespace SoftUniClone.Web.Areas.Admin.Controllers.Account
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class UsersController : BaseController
    {
        public UsersController(SoftUniCloneDbContext db) : base(db)
        {
        }


        public IActionResult Index()
        {
            var users = this.db.Users
                .ProjectTo<AllUsersModel>()
                .ToList();

            return View(users);
        }

    }
}