using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbar(UserManager<AppUser> userManager) : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = user.Name + " " + user.Surname;
            return View();
        }

    }
}