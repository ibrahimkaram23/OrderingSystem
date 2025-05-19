using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Command.Models
{
    public class RefreshTokenCommand:IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
