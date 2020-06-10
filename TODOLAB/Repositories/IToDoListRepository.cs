using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOLAB.Model.DTO;

namespace TODOLAB.Repositories
{
    public interface IToDoListRepository
    {
        public Task<IEnumerable<ToDoListDTO>> GetAllToDOList();
        public Task<ToDoListDTO> GetOneToDoList(int id);
        Task<bool> UpdateToDoList(int id, ToDoListDTO list);
        Task<ToDoListDTO> SaveNewToDoList(ToDoListDTO list);
        Task<ToDoListDTO> DeleteToDoList(int id);
    }
}
