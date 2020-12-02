using Microsoft.AspNetCore.Mvc;
using PolyBook.Domain;

namespace PolyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}