using CRM.Application.Common.Exceptions;
using CRM.Application.Interfaces;
using CRM.Domain;
using MediatR;

namespace CRM.Application.CRM.Application.CRM.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly ICRMDbContext _dbContext;

        public DeleteNoteCommandHandler(ICRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellation)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellation);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(CoffeeCRM),cancellation);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellation);

            return Unit.Value;
        }
    }
}
