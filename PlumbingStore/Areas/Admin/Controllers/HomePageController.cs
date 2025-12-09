using EntityLayer.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;
using System.Threading.Tasks;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController(IHomePageService _homePageService) : Controller
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
            await _homePageService.AddAsync(input);
            return RedirectToAction(nameof(Index));
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
            await _homePageService.UpdateAsync(homePage);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteHomePage(int id)
        {
            await _homePageService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
