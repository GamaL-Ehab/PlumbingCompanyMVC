using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(
        IServiceService _serviceService,
        IValidator<ServiceAddVM> _addValidator,
        IValidator<ServiceUpdateVM> _updateValidator
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetAllAsync();
            return View(services);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceAddVM input)
        {
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _serviceService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _serviceService.GetById(id);
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceUpdateVM service)
        {
            var validation = await _updateValidator.ValidateAsync(service);
            if (validation.IsValid)
            {
                await _serviceService.UpdateAsync(service);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(service);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
