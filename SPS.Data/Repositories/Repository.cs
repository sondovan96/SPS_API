using Microsoft.EntityFrameworkCore;
using SPS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task<TEntity> FindAsync(Guid Id)
        {
            return await _context.FindAsync(Id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.ToList();
        }

        public IQueryable<TEntity> InitQuery()
        {
            return _context;
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveById(Guid Id)
        {
            TEntity entity = _context.Find(Id);
            _context.Remove(entity);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(ICollection<TEntity> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
