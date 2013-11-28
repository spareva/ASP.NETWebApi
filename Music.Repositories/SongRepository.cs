using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Data;
using Music.Models;
using System.Data.Entity;

namespace Music.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
    }

    class SongRepository : ISongRepository
    {
        private DbContext dbContext;
        private DbSet<Song> entitySet;

        public SongRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Song>();
        }

        public Song Add(Song entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Song Update(int id, Song entity)
        {
            var toUpdate = this.entitySet.Where(a => a.SongId == id).First();
            toUpdate = entity;
            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Song Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Song> All()
        {
            return this.entitySet;
        }

        public IQueryable<Song> Find(System.Linq.Expressions.Expression<Func<Song, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
