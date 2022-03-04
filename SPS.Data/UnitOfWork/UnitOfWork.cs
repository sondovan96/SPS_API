using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SPS.Data.Models;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
        }

        public async Task RollbackAsync(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            ValidateDate();
            var result = await _context.SaveChangesAsync();
            return result;
        }
        private void ValidateDate()
        {
            var entries = _context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAuditEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IAuditEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
