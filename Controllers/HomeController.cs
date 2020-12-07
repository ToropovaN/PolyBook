using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyBook.Domain;
using PolyBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db = context;
        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public IActionResult Library()
        {
            ViewData["GalleryNum"] = 1;
            return View("Gallery");
        }

        public IActionResult Market()
        {
            ViewData["GalleryNum"] = 2;
            return View("Gallery");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
