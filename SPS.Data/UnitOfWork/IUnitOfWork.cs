using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitAsync(IDbContextTransaction transaction);
        void Dispose();
        Task RollbackAsync(IDbContextTransaction transaction);
        Task<int> SaveChangesAsync();
    }
}
