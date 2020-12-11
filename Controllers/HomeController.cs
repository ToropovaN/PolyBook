using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyBook.Domain;
using PolyBook.Models;
using PolyBook.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
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

        public IActionResult Search()
        {
            return View("Gallery", new GalleryViewModel(2, Config.gallery2, dataManager.Notes.GetNotes()));
        }

        public IActionResult Recommend()
        {
            return View("Gallery", new GalleryViewModel(3, Config.gallery3, dataManager.Notes.GetNotes()));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
