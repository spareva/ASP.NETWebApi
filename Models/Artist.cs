using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Album> Albums;
        public ICollection<Song> Songs;

        public Artist()
        {
        }

        public Artist(string name, string country, DateTime birthDate)
        {
            this.Name = name;
            this.Country = country;
            this.DateOfBirth = birthDate;
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }
    }
}
