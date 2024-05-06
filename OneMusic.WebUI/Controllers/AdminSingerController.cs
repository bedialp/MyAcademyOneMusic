﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Validators;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
	public class AdminSingerController : Controller
	{
		private readonly ISingerService _singerService;

		public AdminSingerController(ISingerService singerService)
		{
			_singerService = singerService;
		}

		public IActionResult Index()
		{
			var values = _singerService.TGetList();
			return View(values);
		}

		// DELETE SINGER PROCESS
		public IActionResult DeleteSinger(int id)
		{
			_singerService.TDelete(id);
			return RedirectToAction("Index");
		}

		// CREATE SINGER PROCESS
		[HttpGet]
		public IActionResult CreateSinger()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateSinger(Singer singer)
		{
			var validator = new SingerValidator();
			ModelState.Clear();
			var result = validator.Validate(singer);
			if (result.IsValid)
			{
				_singerService.TCreate(singer);
				return RedirectToAction("Index");
			}
			result.Errors.ForEach(x =>
			{
				ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
			});
			return View();
		}

		// UPDATE SINGER PROCESS
		[HttpGet]
		public IActionResult UpdateSinger(int id)
		{
			var values = _singerService.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateSinger(Singer singer)
		{
			_singerService.TUpdate(singer);
			return RedirectToAction("Index");
		}
	}
}