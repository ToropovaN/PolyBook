using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyBook.Areas.Admin.Controllers;
using PolyBook.Domain;
using PolyBook.Domain.Entities;
using PolyBook.Service;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public BooksController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Book() : dataManager.Books.GetBookById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Book model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    model.ImagePath = model.Title + ImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "img/photos/", model.Title + ImageFile.FileName), FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }
                }
                dataManager.Books.SaveBook(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Books.DeleteBook(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}