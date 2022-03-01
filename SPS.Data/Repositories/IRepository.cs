using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        public IQueryable<TEntity> InitQuery();
        public ICollection<TEntity> GetAll();
        public Task<TEntity> FindAsync(Guid Id);
        public Task AddAsync(TEntity entity);
        public Task AddRangeAsync(ICollection<TEntity> entities);
        public void Update(TEntity entity);
        public void UpdateRange(ICollection<TEntity> entities);
        public void Remove(TEntity entity);
        public void RemoveRange(ICollection<TEntity> entities);
        public void RemoveById(Guid Id);
    }
}
