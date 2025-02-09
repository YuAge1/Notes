using AutoMapper;
using CRM.Application.Common.Exceptions;
using CRM.Application.Interfaces;
using CRM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRM.Application.CRM.Queries.GetNoteDetails
{
    public class GetNotesDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly ICRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNotesDetailsQueryHandler(ICRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(CoffeeCRM), cancellationToken);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
