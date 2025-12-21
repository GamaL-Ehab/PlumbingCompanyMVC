using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController(
        IHomePageService _homePageService,
        IValidator<HomePageAddVM> _addValidator,
        IValidator<HomePageUpdateVM> _updateValidator
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var homePages = await _homePageService.GetAllAsync();
            return View(homePages);
        }

        [HttpGet]
        public IActionResult AddHomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomePage(HomePageAddVM input)
        {
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _homePageService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHomePage(int id)
        {
            var homePage = await _homePageService.GetById(id);
            return View(homePage);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHomePage(HomePageUpdateVM homePage)
        {
            var validation = await _updateValidator.ValidateAsync(homePage);
            if (validation.IsValid)
            {
                await _homePageService.UpdateAsync(homePage);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(homePage);
        }

        public async Task<IActionResult> DeleteHomePage(int id)
        {
            await _homePageService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
