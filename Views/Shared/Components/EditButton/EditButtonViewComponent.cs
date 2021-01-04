using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PolyBook.Domain;
using PolyBook.Domain.Entities;
using PolyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolyBook.Views.Shared.Components
{
    public class EditButtonViewComponent : ViewComponent
    {
        private readonly AppDbContext context;
        public EditButtonViewComponent(AppDbContext context)
        {
            this.context = context;
        }

        public ViewViewComponentResult Invoke(Book book)
        {
            bool isOwner = false;
            AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            string UserID = CurrentUser.Id;
            if (book.OwnerID == Guid.Parse(UserID) || User.IsInRole("admin"))
            {
                isOwner = true;
            }
            return View(new EditButtonViewModel(book, isOwner));
        }

    }
}
