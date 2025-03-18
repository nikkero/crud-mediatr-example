using MediatR;
using Todo.Persistence;

namespace Todo.Application.Todo.Commands.DeleteTodoCommand
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly TodoDbContext _context;

        public DeleteTodoCommandHandler(TodoDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteTodoCommand request, 
            CancellationToken cancellation)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null) return false;

            _context.TodoItems.Remove(todoItem);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
