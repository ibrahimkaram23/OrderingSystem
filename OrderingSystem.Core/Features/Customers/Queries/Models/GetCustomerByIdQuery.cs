
using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using OrderingSystem.Core.Wrappers;

namespace OrderingSystem.Core.Features.Customers.Queries.Models
{
    public class GetCustomerByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
    }
}
