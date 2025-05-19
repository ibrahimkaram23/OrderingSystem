using MediatR;
using OrderingSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Queires.Models
{
    public class ConfirmResetPasswordQuery:IRequest<Response<string>>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
