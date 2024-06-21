﻿using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Concrete
{
    public class SongManager(ISongDal songDal) : ISongService
    {
        private readonly ISongDal _songDal = songDal;

        public void TCreate(Song entity)
        {
            _songDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _songDal.Delete(id);
        }

        public Song TGetById(int id)
        {
            return _songDal.GetById(id);
        }

        public List<Song> TGetList()
        {
            return _songDal.GetList();
        }

        public List<Song> TGetSongWithAlbumAndArtist(int id)
        {
            return _songDal.GetSongsWithAlbumAndArtist(id);
        }

        public List<Song> TGetSongWithAlbumByUserId(int id)
        {
            return _songDal.GetSongsWithAlbumByUserId(id);
        }

        public List<Song> TGetSongWithAlbum()
        {

            return _songDal.GetSongWithAlbum();
        }

        public void TUpdate(Song entity)
        {
            _songDal.Update(entity);
        }
    }
}