using MediatR;

namespace Todo.Application.Todo.Commands.CreateTodoCommand
{
    public class CreateTodoCommand : IRequest<Guid>
    {
        public string Title { get; set; }
    }
}
