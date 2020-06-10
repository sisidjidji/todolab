using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model;

namespace TODOLAB.Repositories
{
    public class UserManagerWrapper : IUserManager
    {
        private readonly UserManager<ToDoUser> userManager;
        private readonly IConfiguration configuration;

        public UserManagerWrapper(UserManager<ToDoUser> userManager , IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        public Task AccessFailedAsync(ToDoUser user)
        {
            return userManager.AccessFailedAsync(user);
        }

        public Task<bool> CheckPasswordAsync(ToDoUser user, string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }

        public Task<IdentityResult> CreateAsync(ToDoUser user, string password)
        {
            return userManager.CreateAsync(user, password);
        }

        public string CreateToken(ToDoUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            };

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddSeconds(10),
                claims: tokenClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public Task<ToDoUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoUser> FindByNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ToDoUser user)
        {
            throw new NotImplementedException();
        }
    }
}
