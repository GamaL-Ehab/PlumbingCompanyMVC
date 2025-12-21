using EntityLayer.WebApplication.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace PlumbingStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(
        ITeamService _teamService,
        IValidator<TeamAddVM> _addValidator,
        IValidator<TeamUpdateVM> _updateValidator
        ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamAddVM input)
        {
            var validation = await _addValidator.ValidateAsync(input);
            if (validation.IsValid)
            {
                await _teamService.AddAsync(input);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetById(id);
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(TeamUpdateVM team)
        {
            var validation = await _updateValidator.ValidateAsync(team);
            if (validation.IsValid)
            {
                await _teamService.UpdateAsync(team);
                return RedirectToAction(nameof(Index));
            }

            validation.AddToModelState(this.ModelState);
            return View(team);
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
