using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model;
using TODOLAB.Model.DTO;

namespace TODOLAB.Repositories
{
    public interface IToDoListRepository 
    {
        public Task<IEnumerable<ToDoListDTO>> GetAllToDOList();
        public Task<ToDoListDTO> GetOneToDoList(int id);
        Task<bool> UpdateToDoList(int id, ToDoList list);
        Task<ToDoListDTO> SaveNewToDoList(ToDoList list);
        Task<ToDoListDTO> DeleteToDoList(int id);
        Task<List<ToDoList>> GetAllPostsByMe(string userId);
    }
}
