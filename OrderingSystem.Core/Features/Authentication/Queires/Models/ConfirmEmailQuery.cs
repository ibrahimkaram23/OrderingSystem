
using MediatR;
using OrderingSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Queires.Models
{
    public class ConfirmEmailQuery:IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
