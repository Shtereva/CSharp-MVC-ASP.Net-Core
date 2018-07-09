using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Web.Models;

namespace CarDealer.Web.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
