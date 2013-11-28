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
    public class SongsController : ApiController
    {
        private IRepository<Song> songsRep;

        public SongsController()
        {
        }

        public SongsController(IRepository<Song> modelsRep)
        {
            this.songsRep = modelsRep;
        }

        public IEnumerable<SongModel> GetAll()
        {
            var songsEntities = this.songsRep.All();
            var songModels = from songEntity in songsEntities
                               select new SongModel()
                               {
                                   SongId = songEntity.SongId,
                                   ArtistId = songEntity.ArtistId,
                                   Genre = songEntity.Genre,
                                   Title = songEntity.Title,
                                   Year = songEntity.Year
                               };
            return songModels.ToList();
        }

        public SongModel GetSingle(int id)
        {
            var entity = this.songsRep.Get(id);
            var model = new SongModel()
            {
                SongId = entity.SongId,
                ArtistId = entity.ArtistId,
                Genre = entity.Genre,
                Title = entity.Title,
                Year = entity.Year
            };

            return model;
        }

        public HttpResponseMessage PostSong(SongModel model)
        {
            var entityToAdd = new Song()
            {
                SongId = model.SongId,
                ArtistId = model.ArtistId,
                Genre = model.Genre,
                Title = model.Title,
                Year = model.Year
            };

            var createdEntity = this.songsRep.Add(entityToAdd);
            var createdModel = new SongModel()
            {
                SongId = model.SongId,
                ArtistId = model.ArtistId,
                Genre = model.Genre,
                Title = model.Title,
                Year = model.Year
            };

            var response = Request.CreateResponse<SongModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.ArtistId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
