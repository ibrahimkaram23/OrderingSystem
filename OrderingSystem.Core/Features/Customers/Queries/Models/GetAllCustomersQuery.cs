
using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using OrderingSystem.Core.Wrappers;

namespace OrderingSystem.Core.Features.Customers.Queries.Models
{
    public class GetAllCustomersQuery : IRequest<Response<PaginatedResult<GetUserByIdResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; } = string.Empty;
    }
    
}
