using Identity.Web.Models;
using Identity.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Identity.Web.Enums;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Identity.Web.Controllers
{


    [Authorize(Roles = "Admin")]
    public class MemberController : BaseController
    {

        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {

        }
        public IActionResult Index()
        {
            AppUser user = CurrentUser;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel passwordChangeViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;

                bool exist = userManager.CheckPasswordAsync(user, passwordChangeViewModel.PasswordOld).Result;

                if (exist)
                {
                    IdentityResult result = userManager.ChangePasswordAsync(user, passwordChangeViewModel.PasswordOld, passwordChangeViewModel.PasswordNew).Result;

                    if (result.Succeeded)
                    {
                        userManager.UpdateSecurityStampAsync(user);

                        signInManager.SignOutAsync();
                        signInManager.PasswordSignInAsync(user, passwordChangeViewModel.PasswordNew, true, false);

                        ViewBag.success = "true";
                    }
                    else
                    {
                        AddModelError(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eski şifreniz yanlış");
                }
            }

            return View(passwordChangeViewModel);
        }

        public IActionResult UserEdit()
        {

            AppUser user = CurrentUser;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel userViewModel, IFormFile userPicture)
        {
            ModelState.Remove("Password");
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;
                if (userPicture != null && userPicture.Length > 0)
                {
                    var fileNmae = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", fileNmae);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await userPicture.CopyToAsync(stream);
                        user.Picture = "/UserPicture/" + fileNmae;
                    };
                }

                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.City = userViewModel.City;
                user.BirthDay = userViewModel.BirthDay;
                user.Gender = (int)userViewModel.Gender;
                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, true);
                    ViewBag.success = "true";
                }
                else
                {
                    AddModelError(result);
                }
            }

            return View(userViewModel);
        }

        public void LogOut()
        {
            signInManager.SignOutAsync();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "editor,Admin")]
        public IActionResult Editor()
        {
            return View();
        }

        [Authorize(Roles = "manager,Admin")]
        public IActionResult Manager()
        {
            return View();
        }

        [Authorize(Policy = "AnkaraPolicy")]
        public IActionResult AnkaraPage()
        {
            return View();
        }
    }
}

    
