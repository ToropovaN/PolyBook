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
    public class BooksController : Controller
    {
        private readonly DataManager dataManager;
        public BooksController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Book(Guid id)
        {
            return View("Book", dataManager.Books.GetBookById(id));
        }
    }
}