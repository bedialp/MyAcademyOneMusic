﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OneMusic.EntityLayer.Entities;
using OneMusic.WebUI.Areas.Artist.Models;

namespace OneMusic.WebUI.Areas.Artist.Controllers
{
	[Area("Artist")]
	[Authorize(Roles = "Artist")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var model = new ArtistEditViewModel
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				Name = user.Name,
				Surname = user.Surname,
				ImageUrl = user.ImageUrl,
				UserName = user.UserName
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(ArtistEditViewModel model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (model.ImageFile != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(model.ImageFile.FileName);
				var imageName = Guid.NewGuid() + extension;
				var saveLocation = resource + "/wwwroot/images/" + imageName;
				var stream = new FileStream(saveLocation, FileMode.Create);
				await model.ImageFile.CopyToAsync(stream);
				user.ImageUrl = "/images/" + imageName;
			}


			user.Email = model.Email;
			user.PhoneNumber = model.PhoneNumber;
			user.Name = model.Name;
			user.Surname = model.Surname;
			//user.ImageUrl = model.ImageUrl;
			user.UserName = model.UserName;
			var result = await _userManager.CheckPasswordAsync(user, model.OldPassword);
			if (result == true)
			{
				if (model.NewPassword != model.ConfirmPassword && model.NewPassword != null)
				{
					var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
					if (!changePasswordResult.Succeeded)
					{
						foreach (var item in changePasswordResult.Errors)
						{
							ModelState.AddModelError("", item.Description);
							return View();
						}
					}
				}

				var updateResult = await _userManager.UpdateAsync(user);
				if (updateResult.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}

			}
			ModelState.AddModelError("", "Eski şifrenizi yanlış girdiniz.");
			return View();
		}
	}
}