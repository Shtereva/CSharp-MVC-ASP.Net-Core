using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    using System.Linq;
    using System.Security.Cryptography;
    using BindingModels;
    using Data;
    using Filters;
    using Microsoft.AspNetCore.Http;
    using static Constants;

    public class UsersController : Controller
    {
        private BookLibraryDbContext db;

        public UsersController(BookLibraryDbContext db)
        {
            this.db = db;
        }
        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var modelPassHash = this.GetPasswordHash(model.Password);

            var user = this.db.Users
                .SingleOrDefault(u =>
                    u.Username == model.Username && u.PasswordHash == modelPassHash);

            if (user == null)
            {
                return this.View();
            }

            this.HttpContext.Session.SetString(CurrentUserSessionKey, model.Username);
            
            return this.RedirectToPage("/Index");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.HttpContext.Session.Clear();

            return this.RedirectToPage("/Index");
        }

        private string GetPasswordHash(string password)
        {
            var sha256 = SHA256.Create();
            return string.Join(
                string.Empty,
                sha256
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                    .Select(b => b.ToString("x2")));
        }
    }
}