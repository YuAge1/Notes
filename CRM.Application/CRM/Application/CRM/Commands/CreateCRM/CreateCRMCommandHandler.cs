using CRM.Application.Interfaces;
using CRM.Domain;
using MediatR;

namespace CRM.Application.CRM.Application.CRM.Commands.CreateCRM
{
    public class CreateCRMCommandHandler : IRequestHandler<CreateCRMCommand, Guid>
    {
        private readonly ICRMDbContext _dbContext;

        public CreateCRMCommandHandler(ICRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCRMCommand request, CancellationToken cancellationToken)
        {
            var note = new CoffeeCRM
            {
                UserId = request.UserId,
                Title = request.Title,
                Detatils = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
