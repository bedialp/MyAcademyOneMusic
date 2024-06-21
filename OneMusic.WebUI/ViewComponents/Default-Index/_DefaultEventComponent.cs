using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultEventComponent(IEventService eventService) : ViewComponent
    {
        private readonly IEventService _eventService = eventService;

        public IViewComponentResult Invoke()
        {
            var values = _eventService.TGetList();
            return View(values);
        }
    }
}
