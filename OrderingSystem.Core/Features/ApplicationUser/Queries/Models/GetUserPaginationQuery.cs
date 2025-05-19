using MediatR;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using OrderingSystem.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery:IRequest<PaginatedResult<GetUserPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
    }
}
