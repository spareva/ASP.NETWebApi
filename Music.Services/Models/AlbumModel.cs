using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.Services.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }

        public virtual ICollection<ArtistModel> Artists { get; set; }
        public virtual ICollection<SongModel> Songs { get; set; }

        public AlbumModel()
        {
        }

        public AlbumModel(string name, string producer, int year)
        {
            this.Title = name;
            this.Producer = producer;
            this.Year = year;
            this.Artists = new HashSet<ArtistModel>();
            this.Songs = new HashSet<SongModel>();
        }
    }
}