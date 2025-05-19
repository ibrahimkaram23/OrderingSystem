﻿using OrderingSystem.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Service.AuthService.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<User> GetuserAsync();
        public int GetuserId();
        public Task<List<string>> GetCurrentusersRolesAsync();
    }
}
