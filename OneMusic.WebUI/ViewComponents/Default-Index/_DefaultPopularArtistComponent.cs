using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultPopularArtistComponent(UserManager<AppUser> _userManager):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.GetUsersInRoleAsync("Artist");
            var descArtist = value.OrderByDescending(x=>x.Id).Take(7).ToList();
            return View(descArtist);
        }
    }
}
