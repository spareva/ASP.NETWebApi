using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Music.Models;

namespace Music.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("MusicDb")
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Album>().Property(a => a.Title).IsRequired();
            //modelBuilder.Entity<Song>().Property(s => s.Title).IsRequired();
            //modelBuilder.Entity<Artist>().Property(a => a.Name).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
