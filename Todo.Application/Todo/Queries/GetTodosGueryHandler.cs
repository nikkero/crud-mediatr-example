using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Domain;
using Todo.Persistence;

namespace Todo.Application.Todo.Queries
{
    public class GetTodosGueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoItem>>
    {
        private readonly TodoDbContext _context;

        public GetTodosGueryHandler(TodoDbContext context) => 
            _context = context;

        public async Task<IEnumerable<TodoItem>> Handle(GetTodosQuery request, 
            CancellationToken cancellationToken)
        {
            return await _context.TodoItems.ToListAsync(cancellationToken);
        }
    }
}
