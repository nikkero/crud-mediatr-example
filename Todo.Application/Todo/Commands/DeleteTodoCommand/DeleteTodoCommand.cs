using MediatR;

namespace Todo.Application.Todo.Commands.DeleteTodoCommand
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
