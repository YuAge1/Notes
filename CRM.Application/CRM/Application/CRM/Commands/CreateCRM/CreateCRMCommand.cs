using MediatR;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class CreateCRMCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
