using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(
        ITestimonialService _testimonialService,
        IValidator<TestimonialAddVM> _addValidator,
        IValidator<TestimonialUpdateVM> _updateValidator
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            return View(testimonials);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialAddVM input)
        {
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _testimonialService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);         
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetById(id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateVM testimonial)
        {
            var validation = await _updateValidator.ValidateAsync(testimonial);
            if (validation.IsValid)
            {
                await _testimonialService.UpdateAsync(testimonial);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(testimonial);        
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
