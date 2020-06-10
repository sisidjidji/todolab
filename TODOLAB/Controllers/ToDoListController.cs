using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TODOLAB.Model;
using TODOLAB.Model.DTO;
using TODOLAB.Repositories;

namespace TODOLAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        IToDoListRepository toDoListRepository;
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListDTO>>> GetToAllToDo()
        {
            return Ok(await toDoListRepository.GetAllToDOList());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListDTO>> GetOneList(int id)
        {
            return Ok(await toDoListRepository.GetOneToDoList(id));
        }

        [HttpPut ("{id}")]

        public async Task<ActionResult<ToDoList>> PutList(int id, ToDoList listtodo)
        {

            if(id != listtodo.Id )
            {
                return BadRequest();
            }

            bool didUpdateList = await toDoListRepository.UpdateToDoList(id, listtodo);

            if(!didUpdateList)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}