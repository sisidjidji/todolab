using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Data;
using TODOLAB.Model.DTO;

namespace TODOLAB.Repositories
{
    public class ToDoListRepository
    {
        private ToDoDbContext _context;

        public ToDoListRepository(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoListDTO>> GetAllToDOList()
        {
            var toDoList = await _context.ToDoList
                .Select(list => new ToDoListDTO
                {
                    Id = list.Id,
                    Name = list.Name,
                    DueDate = list.DueDate
                }).ToListAsync();

            return toDoList;
        }

    }
}
