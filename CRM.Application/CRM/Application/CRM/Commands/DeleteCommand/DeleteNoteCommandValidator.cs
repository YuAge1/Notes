using CRM.Application.CRM.Application.CRM.Commands.UpdateCRM;
using FluentValidation;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class DeleteNoteCommandValidator : AbstractValidator<UpdateCRMCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand =>
            createNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
