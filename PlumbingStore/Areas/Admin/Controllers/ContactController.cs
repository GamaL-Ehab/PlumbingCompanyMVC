using EntityLayer.WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;
using System.Threading.Tasks;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(IContactService _contactService) : Controller
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
            await _contactService.AddAsync(input);
            return RedirectToAction(nameof(Index));
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
            await _contactService.UpdateAsync(contact);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
