using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PolyBook.Domain;
using PolyBook.Domain.Entities;
using PolyBook.Models;
namespace PolyBook.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;
        private readonly DataManager dataManager;
        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr, AppDbContext context, DataManager dataManager)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            this.context = context;
            this.dataManager = dataManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Неверный E-mail или пароль");
            }
            return View(model);
        }
     
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new RegisterViewModel());
        }

     [HttpPost]
     [AllowAnonymous]
     public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
     {
         if (ModelState.IsValid)
         {
                AppUser checkemail = await userManager.FindByEmailAsync(model.Email);
                if (checkemail == null)
                {
                    Random rnd = new Random();
                    int imagenumber = rnd.Next(1, 10);

                    AppUser user = new AppUser { UserName = model.Email, Name = model.Name, Surname = model.Surname, Email = model.Email, Image = "img/accounts/" + imagenumber.ToString() };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return Redirect(returnUrl ?? "/");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else { ModelState.AddModelError(nameof(RegisterViewModel.Email), "Пользователь с таким E-mail уже зарегистрирован"); }
         }
         return View(model);
     }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]

        public IActionResult MyBooks()
        {
            AppUser CurrentUser = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            Guid UserID = Guid.Parse(CurrentUser.Id);
            return View("Gallery", new GalleryViewModel(3, "Мои книги", dataManager.Books.GetBooksByOwnerId(UserID)));
        }
    }
}