using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model;

namespace TODOLAB.Data
{
    public class UserToDoDbContext :IdentityDbContext<ToDoUser>
    {
        public UserToDoDbContext(DbContextOptions <UserToDoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole
            {
                Id = "admin",
                Name = "Administrator",
                ConcurrencyStamp = "08bb4973-5be0-4567-8900-b5be9ffe2caa",
            };
            var moderator = new IdentityRole
            {
                Id = "moderator",
                Name = "Moderator",
                ConcurrencyStamp = "8698dfd2-519e-41b0-8a90-20585fb82d94",
            };
            builder.Entity<IdentityRole>()
                .HasData(admin, moderator);
        }
    }
}
