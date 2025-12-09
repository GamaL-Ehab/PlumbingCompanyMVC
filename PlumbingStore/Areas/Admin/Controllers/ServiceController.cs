using EntityLayer.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IServiceService _serviceService) : Controller
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
            await _serviceService.AddAsync(input);
            return RedirectToAction(nameof(Index));
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
            await _serviceService.UpdateAsync(service);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
