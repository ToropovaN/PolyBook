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
    public class ProfileViewComponent : ViewComponent
    {
        private readonly AppDbContext context;
        public ProfileViewComponent(AppDbContext context)
        {
            this.context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            string UserID = CurrentUser.Id;
            string UserName = CurrentUser.Name;
            string UserSurname = CurrentUser.Surname;
            string UserEmail = CurrentUser.Email;
            string UserImage = CurrentUser.Image;
            return View(new ProfileViewModel(UserID, UserName, UserSurname, UserEmail, UserImage));
        }

    }
}
