using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController(
        IPortfolioService _portfolioService,
        IValidator<PortfolioAddVM> _addValidator,
        IValidator<PortfolioUpdateVM> _updateValidator
        ) : Controller
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
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _portfolioService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
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
            var validation = await _updateValidator.ValidateAsync(portfolio);
            if (validation.IsValid)
            {
                await _portfolioService.UpdateAsync(portfolio);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(portfolio);
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
