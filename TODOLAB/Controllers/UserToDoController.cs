using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TODOLAB.Model;
using TODOLAB.Model.Identity;
using TODOLAB.Repositories;

namespace TODOLAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToDoController : Controller
    {
        private readonly IUserManager userManager;

        public UserToDoController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var user = await userManager.FindByNameAsync(login.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new UserWithToken
                    {
                        UserId = user.Id,
                        Token = userManager.CreateToken(user)

                    });
                }

                await userManager.AccessFailedAsync(user);
            }
            return Unauthorized();
        }

        [HttpPost("Register")]

        public async Task<IActionResult>Register(RegisterData register)
        {
            var user = new ToDoUser
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName

            };

            var result = await userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "registration failed",
                    errors = result.Errors
                });
            }

            return Ok(new UserWithToken
            {
                UserId =user.Id,
                Token=userManager.CreateToken(user)
            });
                

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult>GetUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                
            });
        }

        [HttpPut ("userId")]

        public async Task <IActionResult> UpdateUser(string userId , UpdateUserData data)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
         
            await userManager.UpdateAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
               
            });
        }
         
    }
}