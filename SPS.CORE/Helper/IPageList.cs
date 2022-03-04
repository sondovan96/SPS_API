using SPS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Core.Helper
{
    public interface IPageList
    {
        public Task<PageListResult<T>> GetPaginationAsync<T>(IQueryable<T> query, int? pageIndex = null, int? pageSize = null);
    }
}
