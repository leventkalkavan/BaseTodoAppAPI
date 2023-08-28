using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BaseAPITodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_todoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _todoRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            await _todoRepository.AddProductAsync(new Todo
                {
                 Description   = todo.Description,
                 Header = todo.Header,
                 CreatedDate = todo.CreatedDate
                });
            await _todoRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _todoRepository.RemoveAsync(id);
            await _todoRepository.SaveAsync();
           return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Todo todo)
        {
             var res = _todoRepository.Update(todo);
             todo.UpdatedDate = DateTime.Now;   
             await _todoRepository.SaveAsync();
             return Ok();
        }
    }
}
