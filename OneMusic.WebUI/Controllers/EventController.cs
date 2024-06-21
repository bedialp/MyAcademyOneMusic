using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Controllers
{
    [AllowAnonymous]
    public class EventController(IEventService eventService) : Controller
    {
        private readonly IEventService _eventService = eventService;

        public IActionResult Index()
        {
            var values = _eventService.TGetList();
            return View(values);
        }
    }
}
