using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand: EditRoleRequest, IRequest<Response<string>>
    {
      
    }
}
