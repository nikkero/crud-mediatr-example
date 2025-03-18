using MediatR;
using Todo.Domain;

namespace Todo.Application.Todo.Queries
{
    public class GetTodosQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
}
