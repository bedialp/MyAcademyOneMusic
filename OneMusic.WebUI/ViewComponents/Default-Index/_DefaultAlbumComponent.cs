﻿using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.ViewComponents.Default_Index
{
    public class _DefaultAlbumComponent(IAlbumService albumService):ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var value = albumService.TGetAlbumsWithArtist();
            return View(value);
        }
    }
}
