using CRM.Application.CRM.Application.CRM.Commands.UpdateCRM;
using FluentValidation;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateCRMCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand =>
            createNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
