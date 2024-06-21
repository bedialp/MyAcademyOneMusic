using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultContactInfoComponent(IContactService _contactService):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _contactService.TGetList();
            return View(value);
        }
    }
}
