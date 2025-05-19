using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Authorization.Queries.Results;
using OrderingSystem.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRoleQuery:IRequest<Response<ManageUserRoleResult>>
    {
        public int UserId { get; set; }
    }
}
