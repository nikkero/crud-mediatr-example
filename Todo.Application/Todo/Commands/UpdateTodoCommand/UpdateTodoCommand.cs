using MediatR;

namespace Todo.Application.Todo.Commands.UpdateTodoCommand
{
    public class UpdateTodoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public bool IsCompleted {  get; set; }
    }
}
