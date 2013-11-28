using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Music.Repositories;
using Music.Services.Models;
using Music.Data;
using Music.Models;

namespace Music.Services.Controllers
{
    public class AlbumsController : ApiController
    {
        private IRepository<Album> albumsRep;

        public AlbumsController(IRepository<Album> modelsRep)
        {
            this.albumsRep = modelsRep;
        }

        public IEnumerable<AlbumModel> GetAll()
        {
            var albumEntities = this.albumsRep.All();
            var albumModels = from albumEntity in albumEntities
                              select new AlbumModel()
                              {
                                  AlbumId = albumEntity.AlbumId,
                                  Title = albumEntity.Title,
                                  Year = albumEntity.Year,
                                  Songs = (from song in albumEntity.Songs
                                          select new SongModel()
                                          {
                                              Title = song.Title,
                                              Year = song.Year,
                                              SongId = song.SongId,
                                              Genre = song.Genre
                                          }).ToList(),
                                  Producer = albumEntity.Producer
                              };
            return albumModels.ToList();
        }

        public AlbumModel GetSingle(int id)
        {
            var entity = this.albumsRep.Get(id);
            var model = new AlbumModel()
            {
                AlbumId = entity.AlbumId,
                Title = entity.Title,
                Year = entity.Year,
                Songs = (from song in entity.Songs
                        select new SongModel()
                        {
                            Title= song.Title,
                            Year = song.Year,
                            SongId = song.SongId,
                            Genre = song.Genre
                        }).ToList(),
                Producer = entity.Producer
            };

            return model;
        }

        public HttpResponseMessage PostAlbum(AlbumModel model)
        {
            var entityToAdd = new Album()
            {
                Title = model.Title,
                Year = model.Year,
                AlbumId = model.AlbumId,
                Producer = model.Producer,
                Songs = (from song in model.Songs
                         select new Song()
                         {
                             Title = song.Title,
                             Year = song.Year,
                             SongId = song.SongId,
                             Genre = song.Genre
                         }).ToList()
            };

            var createdEntity = this.albumsRep.Add(entityToAdd);

            var createdModel = new AlbumModel()
            {
                AlbumId = createdEntity.AlbumId,
                Title = createdEntity.Title
            };

            var response = Request.CreateResponse<AlbumModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.AlbumId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
