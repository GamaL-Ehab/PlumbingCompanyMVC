using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(
        IAboutService _aboutService, 
        IValidator<AboutAddVM> _addValidator, 
        IValidator<AboutUpdateVM> _updateValidator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutAddVM input) 
        { 
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _aboutService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id) 
        {
            var about = await _aboutService.GetById(id);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutUpdateVM about) 
        {
            var validation = await _updateValidator.ValidateAsync(about);
            if (validation.IsValid)
            {
                await _aboutService.UpdateAsync(about);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(about);
        }

        public async Task<IActionResult> DeleteAbout(int id) 
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
