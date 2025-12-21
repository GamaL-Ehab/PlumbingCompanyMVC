using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(
        IContactService _contactService,
        IValidator<ContactAddVM> _addValidator,
        IValidator<ContactUpdateVM> _updateValidator
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetAllAsync();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactAddVM input)
        {
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _contactService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id) 
        {
            var contact = await _contactService.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactUpdateVM contact)
        {
            var validation = await _updateValidator.ValidateAsync(contact);
            if (validation.IsValid)
            {
                await _contactService.UpdateAsync(contact);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(contact);      
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
