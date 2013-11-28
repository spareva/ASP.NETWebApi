using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.Services.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<AlbumModel> Albums;
        public ICollection<SongModel> Songs;

        public ArtistModel()
        {
        }

        public ArtistModel(string name, string country, DateTime birthDate)
        {
            this.Name = name;
            this.Country = country;
            this.DateOfBirth = birthDate;
            this.Albums = new HashSet<AlbumModel>();
            this.Songs = new HashSet<SongModel>();
        }
    }
}