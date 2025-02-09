using CRM.Application.CRM.Application.CRM.Commands.UpdateCRM;
using FluentValidation;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class GetNoteListQueryValidator : AbstractValidator<UpdateCRMCommand>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
