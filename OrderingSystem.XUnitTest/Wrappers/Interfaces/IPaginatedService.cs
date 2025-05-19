using AffiliateMarketing.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateMarketing.XUnitTest.Wrappers.Interfaces
{
    public interface IPaginatedService<T>
    {
        public Task<PaginatedResult<T>> ReturnPaginatedResult(IQueryable<T> source, int PageNumber, int PageSize);
    }

    
}
