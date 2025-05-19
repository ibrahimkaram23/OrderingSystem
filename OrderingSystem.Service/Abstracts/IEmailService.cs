﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Service.Abstracts
{
    public interface IEmailService
    {
        public Task<string> SendEmail(string email,string Message,string? reason);
    }
}
