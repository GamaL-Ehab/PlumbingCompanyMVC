using EntityLayer.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> GetAboutList()
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
            await _aboutService.AddAsync(input);
            return RedirectToAction(nameof(GetAboutList));
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
            await _aboutService.UpdateAsync(about);
            return RedirectToAction(nameof(GetAboutList));
        }

        public async Task<IActionResult> DeleteAbout(int id) 
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction(nameof(GetAboutList));
        }

    }
}
