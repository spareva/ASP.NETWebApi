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
    public class ArtistsController : ApiController
    {
        private IRepository<Artist> artistsRep;

        public ArtistsController(IRepository<Artist> modelsRep)
        {
            this.artistsRep = modelsRep;
        }

        public IEnumerable<ArtistModel> GetAll()
        {
            var artistEntities = this.artistsRep.All();
            var artistModels = from artistEntity in artistEntities
                               select new ArtistModel()
                              {
                                  ArtistId = artistEntity.ArtistId,
                                  Name = artistEntity.Name,
                                  DateOfBirth = artistEntity.DateOfBirth,
                                  Country = artistEntity.Country
                              };
            return artistModels.ToList();
        }

        public ArtistModel GetSingle(int id)
        {
            var entity = this.artistsRep.Get(id);
            var model = new ArtistModel()
            {
                ArtistId = entity.ArtistId,
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                Country = entity.Country
            };

            return model;
        }

        public HttpResponseMessage PostArtist(ArtistModel model)
        {
            var entityToAdd = new Artist()
            {
                ArtistId = model.ArtistId,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Country = model.Country
            };

            var createdEntity = this.artistsRep.Add(entityToAdd);
            var createdModel = new ArtistModel()
            {
                ArtistId = createdEntity.ArtistId,
                Name = createdEntity.Name
            };

            var response = Request.CreateResponse<ArtistModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.ArtistId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
