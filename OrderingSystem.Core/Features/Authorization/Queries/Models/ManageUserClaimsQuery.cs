using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Data.Helpers;
using OrderingSystem.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery:IRequest<Response<ManageUserClaimResult>>
    {
        public int UserId { get; set; }
    }
}
