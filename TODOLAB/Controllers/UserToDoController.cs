using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    }
}