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
    public interface IArtistRepository : IRepository<Artist>
    {
    }

    class ArtistRepository : IArtistRepository
    {
        private DbContext dbContext;
        private DbSet<Artist> entitySet;

        public ArtistRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Artist>();
        }

        public Artist Add(Artist entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Artist Update(int id, Artist entity)
        {
            var toUpdate = this.entitySet.Where(a => a.ArtistId == id).First();
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

        public Artist Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> All()
        {
            return this.entitySet;
        }

        public IQueryable<Artist> Find(System.Linq.Expressions.Expression<Func<Artist, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
