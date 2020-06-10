using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Data;
using TODOLAB.Model;
using TODOLAB.Model.DTO;

namespace TODOLAB.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoDbContext _context;

        public ToDoListRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public Task<ToDoListDTO> DeleteToDoList(int id)
        {
            throw new NotImplementedException();
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

        public async Task<ToDoListDTO> GetOneToDoList(int id)
        {
            var list = await  _context.ToDoList
                .Select(e => new ToDoListDTO
                {
                    Id = e.Id,
                    DueDate = e.DueDate,
                    Name = e.Name

                }).FirstOrDefaultAsync(list => list.Id == id);;

            return list;
        }

      

        public Task<ToDoListDTO> SaveNewToDoList(ToDoList list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoList(int id, ToDoList list)
        {
            throw new NotImplementedException();
        }
    }
}
