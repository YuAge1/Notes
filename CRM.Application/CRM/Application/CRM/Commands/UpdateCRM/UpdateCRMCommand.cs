using MediatR;

namespace CRM.Application.CRM.Application.CRM.Commands.UpdateCRM
{
    public class UpdateCRMCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
