using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        public Song()
        {
        }

        public Song(string name, string genre, int year)
        {
            this.Title = name;
            this.Genre = genre;
            this.Year = year;
        }
    }
}
