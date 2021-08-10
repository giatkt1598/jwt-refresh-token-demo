using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BaseConnect
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        int Count();
        TEntity Get<TKey>(TKey id);
        Task<TEntity> GetAsyn<TKey>(TKey id);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault();
        
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsyn();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task UpdateAsyn(TEntity entity);
        TEntity Delete(TEntity entity);
        Task DeleteAsyn(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsyn(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsyn(IEnumerable<TEntity> entities);
        void Save();
        Task SaveAsync();
    }
}
