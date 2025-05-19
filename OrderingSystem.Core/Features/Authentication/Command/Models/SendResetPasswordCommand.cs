﻿using MediatR;
using OrderingSystem.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Core.Features.Authentication.Command.Models
{
    public class SendResetPasswordCommand:IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
