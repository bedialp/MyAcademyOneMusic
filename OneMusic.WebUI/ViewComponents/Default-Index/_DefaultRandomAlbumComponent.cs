using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultRandomAlbumComponent(ISongService _songService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _songService.TGetSongWithAlbum().ToList();
            var random = new Random(); 
            var randomValue = value.OrderBy(x=>random.Next()).Take(1).ToList();
            return View(randomValue);
        }
    }

}