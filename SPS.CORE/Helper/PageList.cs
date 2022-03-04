using Microsoft.EntityFrameworkCore;
using SPS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Core.Helper
{
    public class PageList : IPageList
    {
        public PageList()
        {

        }
        public async Task<PageListResult<T>> GetPaginationAsync<T>(IQueryable<T> query, int? pageIndex = null, int? pageSize = null)
        {
            var pageList = new PageListResult<T>();
            pageList.PageIndex = !pageIndex.HasValue || pageIndex < 1 ? 1 : pageIndex.Value;
            pageList.PageSize = (!pageSize.HasValue || pageSize < 0) ? Constants.Constants.ApplicationSettings.DefaultValues.PageSize : pageSize.Value;
            pageList.TotalItems = await query.CountAsync();
            pageList.TotalPages = pageList.TotalItems / pageList.PageSize;

            if(pageList.TotalItems % pageList.PageSize>0)
            {
                pageList.TotalPages++;
            }

            pageList.Source = await query.Skip((pageList.PageIndex - 1) * pageList.PageSize).Take(pageList.PageSize).ToArrayAsync();
            return pageList;
        }
    }
}
