using AutoMapper;
using CRM.Application.Common.Mappings;
using CRM.Domain;

namespace CRM.Application.CRM.Application.CRM.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<CoffeeCRM>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CoffeeCRM, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                    opt => opt.MapFrom(note => note.Title));
        }
    }
}
