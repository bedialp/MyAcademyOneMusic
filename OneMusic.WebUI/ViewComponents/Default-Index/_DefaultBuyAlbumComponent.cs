using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBuyAlbumComponent(IAlbumService _albumService) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _albumService.TGetList().OrderByDescending(x=>x.CategoryId).Take(7).ToList();
            return View(values);
        }
    }
}
