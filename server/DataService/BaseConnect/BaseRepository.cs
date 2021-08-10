using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BaseConnect
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected BaseDbContext dbContext;

        protected DbSet<TEntity> dbSet;
        public BaseRepository(BaseDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public async Task AddRangeAsyn(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public TEntity Create(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return dbSet.Remove(entity).Entity;
        }


        public TEntity FirstOrDefault()
        {
            return this.dbSet.FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsyn()
        {
            return this.dbSet.FirstOrDefaultAsync();
        }

        public Task<TEntity> FirstOrDefaultAsyn(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.FirstOrDefaultAsync(predicate);
        }
        public IQueryable<TEntity> Get()
        {
            return this.dbSet;
        }

        public TEntity Get<TKey>(TKey id)
        {
            return (TEntity)this.dbSet.Find(new object[1] { id });
        }


        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public async Task<TEntity> GetAsyn<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(new object[1] { id });
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            return dbSet.Update(entity).Entity;
        }

    }
}
