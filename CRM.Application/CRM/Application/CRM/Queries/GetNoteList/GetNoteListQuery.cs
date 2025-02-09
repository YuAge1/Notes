using MediatR;

namespace CRM.Application.CRM.Application.CRM.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
