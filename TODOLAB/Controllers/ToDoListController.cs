using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public object ClaimType { get; private set; }
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository;
        }

        [Authorize]
        [HttpGet("Mine")]
        public async Task<List<ToDoList>> GetMine()
        {
           return await toDoListRepository.GetAllPostsByMe(GetUserId());
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

        public async Task<ActionResult<ToDoList>> PutList(int id, [FromBody]ToDoList listtodo)
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

        [HttpDelete("{id}")]

        public async Task<ActionResult<ToDoListDTO>> DeleteList(int id)
        {
            return Ok(await toDoListRepository.DeleteToDoList(id));
        }

        [HttpPost]
        [Authorize]

        public async  Task<ActionResult<ToDoListDTO>> SaveNewList([FromBody]ToDoList listToDo)
        {
            await toDoListRepository.SaveNewToDoList(listToDo);

            return CreatedAtAction("GetStore", new { id = listToDo.Id }, listToDo);
        }

        private string GetUserId()
        {
            return ((ClaimsIdentity)User.Identity).FindFirst("UserId")?.Value;
        }
    }
}