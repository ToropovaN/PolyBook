using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyBook.Domain;
using PolyBook.Domain.Entities;
using PolyBook.Models;
using PolyBook.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PolyBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly DataManager dataManager;
        private readonly AppDbContext context;
        public HomeController(DataManager dataManager, UserManager<AppUser> userMgr, AppDbContext context)
        {
            this.dataManager = dataManager;
            userManager = userMgr;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(dataManager.Books.GetBooks());
        }

        public IActionResult Library()
        {
            return View("Gallery", new GalleryViewModel(0, Config.gallery0, dataManager.Books.GetBooks()));
        }

        public IActionResult Market()
        {
            return View("Gallery", new GalleryViewModel(1, Config.gallery1, dataManager.Books.GetBooks()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}