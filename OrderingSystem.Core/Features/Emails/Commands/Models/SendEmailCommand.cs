using MediatR;
using OrderingSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommand:IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
