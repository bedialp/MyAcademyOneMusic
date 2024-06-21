using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBannerComponent(IBannerService bannerService) : ViewComponent
    {
        private readonly IBannerService _bannerService = bannerService;

        public IViewComponentResult Invoke()
        {
            var value = _bannerService.TGetList();

            return View(value);
        }
    }
}
