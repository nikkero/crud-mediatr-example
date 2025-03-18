using MediatR;
using Todo.Domain;
using Todo.Persistence;

namespace Todo.Application.Todo.Commands.CreateTodoCommand
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly TodoDbContext _context;

        public CreateTodoCommandHandler(TodoDbContext context) =>
            _context = context;

        public async Task<Guid> Handle(CreateTodoCommand request, 
            CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem 
            { 
                Id = Guid.NewGuid(),
                Title = request.Title,
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
            return todoItem.Id;
        }
    }
}
