using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model;

namespace TODOLAB.Repositories
{
    interface IUserManager
    {
        Task<ToDoUser> FindByNameAsync(string username);
        Task<bool> CheckPasswordAsync(ToDoUser user, string password);
        Task AccessFailedAsync(ToDoUser user);
        Task<IdentityResult> CreateAsync(ToDoUser user, string password);
        Task<ToDoUser> FindByIdAsync(string userId);
        Task<IdentityResult> UpdateAsync(ToDoUser user);
        string CreateToken(ToDoUser user);
    }
}
