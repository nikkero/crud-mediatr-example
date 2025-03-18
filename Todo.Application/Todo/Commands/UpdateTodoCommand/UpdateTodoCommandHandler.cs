using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Persistence;

namespace Todo.Application.Todo.Commands.UpdateTodoCommand
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly TodoDbContext _context;

        public UpdateTodoCommandHandler(TodoDbContext context) => _context = context;

        public async Task<bool> Handle(UpdateTodoCommand request, 
            CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null) return false;

            todoItem.Title = request.Title;
            todoItem.IsCompleted = request.IsCompleted;

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }
    }
}
