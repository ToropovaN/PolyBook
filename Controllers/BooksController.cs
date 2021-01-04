using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PolyBook.Domain;
using PolyBook.Domain.Entities;
using PolyBook.Models;
using PolyBook.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Controllers
{
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

        public IActionResult Book(Guid id)
        {
            Book book = dataManager.Books.GetBookById(id);
            if (book == null) {return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController()); }
            return View("Book", book);
        }

        [Authorize]
        public IActionResult Edit(Guid id)
        {
            Book entity;
            if (id == default) { entity = new Book(); }
            else
            {
                entity = dataManager.Books.GetBookById(id);
                AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                string UserID = CurrentUser.Id;
                if (entity.OwnerID != Guid.Parse(UserID))
                {
                    if (!User.IsInRole("admin"))
                    {
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                    }
                }
            }
            return View(entity);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Book model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (model.OwnerID == default)
                {
                    AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                    string UserID = CurrentUser.Id;
                    model.OwnerID = Guid.Parse(UserID);
                }
                string BookOwnerID = model.OwnerID.ToString();
                AppUser BookOwner = context.Users.FirstOrDefault(x => x.Id == BookOwnerID);
                model.OwnerName = BookOwner.Name + " " + BookOwner.Surname;
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

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            Book CurrentBook = context.Books.FirstOrDefault(x => x.Id == id);
            string UserID = CurrentUser.Id;

            if (CurrentBook.OwnerID != Guid.Parse(UserID))
            {
                if (!User.IsInRole("admin"))
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                }
            }

            dataManager.Books.DeleteBook(CurrentBook);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}