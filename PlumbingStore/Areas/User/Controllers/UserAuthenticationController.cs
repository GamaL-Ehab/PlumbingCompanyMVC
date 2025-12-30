using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity;

namespace PlumbingStore.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserAuthenticationController
        (
        UserManager<AppUser> _userManager,
        SignInManager<AppUser> _signInManager,
        IMapper _mapper,
        IValidator<UserEditVM> _userEditValidator
        )
        : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var mappedUser = _mapper.Map<UserEditVM>(user);
            return View(mappedUser);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditVM request)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var validation = await _userEditValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user!, request.Password);
            if (!isPasswordValid)
            {
                ViewBag.Result = "Failed!";
                ModelState.AddModelErrorsList(new List<string> { "Incorrect Password!" });
                return View();
            }

            if (request.NewPassword is not null)
            {
                var changePassword = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
                if (!changePassword.Succeeded)
                {
                    ViewBag.Result = "NewPassFailed!";
                    ModelState.AddModelErrorsList(changePassword.Errors);
                    return View();
                }
            }

            var oldFileName = user!.FileName;
            var oldFileType = user.FileType;

            if (request.Photo is not null)
            {
                request.FileName = DateTime.Now.ToString();
                request.FileType = DateTime.Now.ToString();
                //Add Photo Logic
            }
            else
            {
                request.FileName = oldFileName;
                request.FileType = oldFileType;
            }

            var mappedUser = _mapper.Map(request, user);
            var updateUser = await _userManager.UpdateAsync(mappedUser);
            if (updateUser.Succeeded)
            {
                if (request.Photo is not null)
                {
                    if (oldFileName is not null)
                    {
                        //Delete Old Image
                    }
                }

                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("index", "Dashboard", new { Area = "User" });
            }

            if (request.FileName is not null)
            {
                //image delete
            }

            if (request.NewPassword is not null)
            {
                await _userManager.ChangePasswordAsync(user!, request.NewPassword, request.Password);
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);
            }

            return View();
        }
    }
}
