using EntityLayer.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;
using System.Threading.Tasks;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController(IPortfolioService _portfolioService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.GetAllAsync();
            return View(portfolios);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioAddVM input)
        {
            await _portfolioService.AddAsync(input);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var portfolio = await _portfolioService.GetById(id);
            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM portfolio)
        {
            await _portfolioService.UpdateAsync(portfolio);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
