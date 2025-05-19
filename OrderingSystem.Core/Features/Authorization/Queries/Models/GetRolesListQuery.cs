using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Authorization.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authorization.Queries.Models
{
     public class GetRolesListQuery:IRequest<Response<List<GetRolesListResult>>>
    {

    }
}
