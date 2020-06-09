using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOLAB.Data
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
