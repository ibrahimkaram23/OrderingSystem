using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.ApplicationUser.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery:IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
