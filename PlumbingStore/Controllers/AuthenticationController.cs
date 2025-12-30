using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Services.Identity.Abstract;
using System.Threading.Tasks;

namespace PlumbingStore.Controllers
{
    public class AuthenticationController(
        UserManager<AppUser> _userManager,
        SignInManager<AppUser> _signInManager,
        IValidator<RegisterVM> _registerValidator,
        IValidator<LoginVM> _loginValidator,
        IValidator<ForgotPasswordVM> _forgotPasswordValidator,
        IValidator<ResetPasswordVM> _resetPasswordValidator,
        IMapper _mapper,
        IAuthenticationCustomService _authenticationCustomService
        ) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM request)
        {
            var validation = await _registerValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(request);
            }

            var user = _mapper.Map<AppUser>(request);
            var userCreatedResult = await _userManager.CreateAsync(user, request.Password);

            if (!userCreatedResult.Succeeded)
            {
                ViewBag.Result = "Check Errors!";
                ModelState.AddModelErrorsList(userCreatedResult.Errors);
                return View();
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM request, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action(nameof(Index), "Dashboard", new {Area = "Admin"});

            var validation = await _loginValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(request);
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                ViewBag.Result = "Invalid Data!";
                ModelState.AddModelErrorsList(new List<string> { "Incorrect email or password!" });
                return View(request);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);

            if (loginResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }

            if (loginResult.IsLockedOut)
            {
                ViewBag.Result = "Locked out!";
                ModelState.AddModelErrorsList(new List<string> { "Your account is locked out for 60 seconds!" });
                return View(request);
            }

            ViewBag.Result = "Invalid Data!";
            ModelState.AddModelErrorsList(new List<string> { $"Incorrect email or password! \n Remaining attempts: {6 - _userManager.GetAccessFailedCountAsync(user).Result}" });
            return View(request);         
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
            var validation = await _forgotPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                ViewBag.Result = "UserDoesNotExist!";
                ModelState.AddModelErrorsList(new List<string> { "User does not exist!" });
                return View();
            }

            await _authenticationCustomService.CreateResetPassLinkAndSentToEmail(user, HttpContext, Url, request);

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token, List<string> errors)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;

            if (errors.Any())
            {
                ViewBag.Result = "error!";
                ModelState.AddModelErrorsList(errors);
            }

            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId is null || token is null)
            {
                return RedirectToAction(nameof(Login));
            }

            var validation = await _resetPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                List<string> errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                return RedirectToAction(nameof(ResetPassword), new { userId, token, errors});
            }

            var user = await _userManager.FindByIdAsync(userId.ToString()!);
            if(user is null)
            {
                return RedirectToAction(nameof(Login));
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user!, token.ToString()!, request.Password);
            if (resetPasswordResult.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                List<string> errors = resetPasswordResult.Errors.Select(x => x.Description).ToList();
                return RedirectToAction(nameof(ResetPassword), new { userId, token, errors });
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
