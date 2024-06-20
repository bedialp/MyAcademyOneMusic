﻿using Microsoft.EntityFrameworkCore;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using OneMusic.DataAccessLayer.Repositories;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Concrete
{
	public class EfSongDal : GenericRepository<Song>, ISongDal
	{
		private readonly OneMusicContext _context;
		public EfSongDal(OneMusicContext context) : base(context)
		{
			_context = context;
		}

		public List<Song> GetSongsWithAlbumAndArtist(int id)
		{
			return _context.Songs.Include(x => x.Album).Where(x => x.AlbumId == id).ToList();
		}

		public List<Song> GetSongsWithAlbumByUserId(int id)
		{
			return _context.Songs.Include(x => x.Album).ThenInclude(x => x.AppUser).Where(x => x.Album.AppUserId == id).ToList();
		}

		public List<Song> GetSongWithAlbum()
		{
			return _context.Songs.Include(s => s.Album).ToList();
		}
	}
}