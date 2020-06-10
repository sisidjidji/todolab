using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admin = new IdentityRole
            {
                Id= "admin",
                Name= "Administrator",
            }
        }
    }
}
