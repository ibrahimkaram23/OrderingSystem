using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Data.Entities.Identity;

namespace OrderingSystem.infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var usersIsCount= await _userManager.Users.CountAsync();
            if(usersIsCount <= 0)
            {
                var defaultuser = new User()
                {
                    UserName="admin",
                    Email="admin@gmail.com",
                    FullName="OrderingSystem",
                    Country="Egypt",
                    PhoneNumber="16464446",
                    Address="Cairo",
                    EmailConfirmed=true,
                    PhoneNumberConfirmed=true,
                };
                await _userManager.CreateAsync(defaultuser,"P@ssw0rd");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
