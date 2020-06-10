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
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(ToDoUser user, string password)
        {
            throw new NotImplementedException();
        }

        public string CreateToken(ToDoUser user)
        {
            throw new NotImplementedException();
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
