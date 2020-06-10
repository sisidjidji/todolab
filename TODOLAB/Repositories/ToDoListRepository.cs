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

        public async Task<ToDoListDTO> DeleteToDoList(int id)
        {
            var listToDo = await _context.ToDoList.FindAsync(id);

            if (listToDo == null)
            {
                return null;
            }

            var storeToReturn = await GetOneToDoList(id);

            _context.ToDoList.Remove(listToDo);


            await _context.SaveChangesAsync();

            return storeToReturn;
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
            var list = await _context.ToDoList
                .Select(e => new ToDoListDTO
                {
                    Id = e.Id,
                    DueDate = e.DueDate,
                    Name = e.Name

                }).FirstOrDefaultAsync(list => list.Id == id); ;

            return list;
        }



        public async Task<ToDoListDTO> SaveNewToDoList(ToDoList listToDo)
        {
            _context.ToDoList.Add(listToDo);

            await _context.SaveChangesAsync();

            return await GetOneToDoList(listToDo.Id);
        }

        public async Task<bool> UpdateToDoList(int id, ToDoList listtodo)
        {
            _context.Entry(listtodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }


        }
        private bool ListExists(int id)
        {
            return _context.ToDoList.Any(e => e.Id == id);

        }

       
    }
}
