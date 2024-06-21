using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
	[AllowAnonymous]
	public class ErrorPageController : Controller
	{
		public IActionResult AccessDenied()
		{
			return View();
		}

		public IActionResult Error404()
		{
			return View();
		}
	}
}
