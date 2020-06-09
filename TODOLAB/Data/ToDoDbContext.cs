using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model;

namespace TODOLAB.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>()
                .HasData(
                new ToDoList
                {
                    Id = 1,
                    Name = "sihem",
                    Assignee = "moi",
                    DueDate = new DateTime(2020, 07, 18)
                },
                 new ToDoList
                 {
                     Id = 2,
                     Name = "louisa",
                     Assignee = "elle",
                     DueDate = new DateTime(2020, 03, 04)
                 });


    }
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
