using AutoMapper;
using AutoMapper.QueryableExtensions;
using CRM.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.CRM.Application.CRM.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly ICRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(ICRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
