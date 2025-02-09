using MediatR;

namespace CRM.Application.CRM.Application.CRM.Commands.DeleteCommand
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
