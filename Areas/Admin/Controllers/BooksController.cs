using System;
using System.IO;
using System.Linq;
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
        private readonly AppDbContext context;
        public BooksController(DataManager dataManager, AppDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            this.context = context;
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
                AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                string UserID = CurrentUser.Id;
                string UserName = CurrentUser.Name + " " + CurrentUser.Surname;
                model.OwnerID = Guid.Parse(UserID);
                model.OwnerName = UserName;
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