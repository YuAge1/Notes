using FluentValidation;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateCRMCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
            createNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
            createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
