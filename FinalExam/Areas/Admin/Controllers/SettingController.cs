using FinalExam.Areas.Admin.ViewModels.Blog;
using FinalExam.Areas.Admin.ViewModels.Settings;
using FinalExam.DAL;
using FinalExam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Setting> setings = await _context.Settings.ToListAsync();
            return View(setings);
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();
            Setting existed = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (existed is null) return NotFound();
            UpdateSettingsVM vm = new()
            {
                Key = existed.Key,
                Value = existed.Value,
            };
            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateSettingsVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Setting existed = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (existed is null) return NotFound();
            existed.Key = vm.Key;
            existed.Value = vm.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}