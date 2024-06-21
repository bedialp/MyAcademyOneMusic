using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class AdminLayoutController(UserManager<AppUser> userManager) : Controller
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.username = user.Name + " " + user.Surname;

            return View();
        }
    }
}