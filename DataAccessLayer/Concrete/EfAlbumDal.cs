using Microsoft.EntityFrameworkCore;
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
    public class EfAlbumDal(OneMusicContext context) : GenericRepository<Album>(context), IAlbumDal
    {
        private readonly OneMusicContext _context = context;

        public List<Album> GetAlbumsByArtist(int id)
        {
            return [.. _context.Albums.Include(y => y.AppUser).Include(a => a.Songs).Where(x => x.AppUserId == id)];
        }

        public List<Album> GetAlbumsWithArtist()
        {
            return [.. _context.Albums.Include(x => x.AppUser).Include(a => a.Songs)];
        }

    }
}