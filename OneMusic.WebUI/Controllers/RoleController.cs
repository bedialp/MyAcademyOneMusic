using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> roleManager) : Controller
    {
        private readonly RoleManager<AppRole> _roleManager = roleManager;

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        // ROLE CREATE ISLEMLERI
        public IActionResult CreateRole() { return View(); }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AppRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        // ROLE DELETE ISLEMLERI
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        // ROLE UPDATE ISLEMLERI
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole role)
        {
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

    }
}
