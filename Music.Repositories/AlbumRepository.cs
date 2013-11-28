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
    public interface IAlbumRepository : IRepository<Album>
    {
    }

    class AlbumRepository : IAlbumRepository
    {
        private DbContext dbContext;
        private DbSet<Album> entitySet;

        public AlbumRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Album Update(int id, Album entity)
        {
            var toUpdate = this.entitySet.Where(a => a.AlbumId == id).First();
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

        public Album Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Album> All()
        {
            return this.entitySet;
        }

        public IQueryable<Album> Find(System.Linq.Expressions.Expression<Func<Album, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
