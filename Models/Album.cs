using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
        }

        public Album(string name, string producer, int year)
        {
            this.Title = name;
            this.Producer = producer;
            this.Year = year;
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }
    }
}
