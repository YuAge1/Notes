using CRM.Application.CRM.Application.CRM.Commands.UpdateCRM;
using FluentValidation;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<UpdateCRMCommand>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand =>
            createNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
