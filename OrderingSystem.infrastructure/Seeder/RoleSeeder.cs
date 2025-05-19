using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var rolesCount= await _roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name="Admin"
                  
                }); 
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Customer"

                });


            }
        }

    }
}
