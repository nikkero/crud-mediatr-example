using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Todo.Commands.CreateTodoCommand;
using Todo.Application.Todo.Commands.DeleteTodoCommand;
using Todo.Application.Todo.Commands.UpdateTodoCommand;
using Todo.Application.Todo.Queries;
using Todo.Domain;

namespace Todo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _mediator.Send(new GetTodosQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateTodoCommand command)
        {
            var todoItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTodoCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteTodoCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
