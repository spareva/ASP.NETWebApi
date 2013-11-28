using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.Services.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        public SongModel()
        {
        }

        public SongModel(string name, string genre, int year)
        {
            this.Title = name;
            this.Genre = genre;
            this.Year = year;
        }
    }
}