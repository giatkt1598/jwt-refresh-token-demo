using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BaseConnect
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected IUnitOfWork unitOfWork;
        protected IBaseRepository<TEntity> repository;
        public BaseService()
        {

        }
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            repository.AddRange(entities);
            unitOfWork.Commit();
        }

        public async Task AddRangeAsyn(IEnumerable<TEntity> entities)
        {
            await repository.AddRangeAsyn(entities);
            await SaveAsync();
        }

        public int Count()
        {
            return repository.Count();
        }

        public TEntity Create(TEntity entity)
        {
            TEntity result = repository.Create(entity);
            Save();
            return result;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await repository.CreateAsync(entity);
            await SaveAsync();
            return result;
        }

        public TEntity Delete(TEntity entity)
        {
            TEntity result = repository.Delete(entity);
            Save();
            return result;
        }

        public async Task DeleteAsyn(TEntity entity)
        {
            repository.Delete(entity);
            await SaveAsync();
        }

        public TEntity FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return repository.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsyn()
        {
            return await repository.FirstOrDefaultAsyn();
        }

        public async Task<TEntity> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.FirstOrDefaultAsyn(predicate);
        }
        public IQueryable<TEntity> Get()
        {
            return repository.Get();
        }

        public TEntity Get<TKey>(TKey id)
        {
            return repository.Get(id);
        }


        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return repository.Get(predicate);
        }

        public async Task<TEntity> GetAsyn<TKey>(TKey id)
        {
            return await repository.GetAsyn(id);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            repository.RemoveRange(entities);
            Save();
        }

        public async Task RemoveRangeAsyn(IEnumerable<TEntity> entities)
        {
            repository.RemoveRange(entities);
            await SaveAsync();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await unitOfWork.CommitAsync();
        }

        public TEntity Update(TEntity entity)
        {
            TEntity result = repository.Update(entity);
            Save();
            return result;
        }

        public async Task UpdateAsyn(TEntity entity)
        {
            repository.Update(entity);
            await SaveAsync();
        }
    }
}
