using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOLAB.Data
{
    public class UserToDoDbContext :DbContext
    {
        public UserToDoDbContext(DbContextOptions <UserToDoDbContext> options) : base(options)
        {

        }
    }
}
