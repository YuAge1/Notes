using CRM.Application.Common.Exceptions;
using CRM.Application.Interfaces;
using CRM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRM.Application.CRM.Commands.UpdateCRM
{
    public class UpdateCRMCommandHandler : IRequestHandler<UpdateCRMCommand, Unit>
    {
        private readonly ICRMDbContext _dbContext;

        public UpdateCRMCommandHandler(ICRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCRMCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(CoffeeCRM), request.Id);
            }

            entity.Detatils = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
