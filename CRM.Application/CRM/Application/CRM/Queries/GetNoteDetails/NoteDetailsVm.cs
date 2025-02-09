using AutoMapper;
using CRM.Application.Common.Mappings;
using CRM.Domain;

namespace CRM.Application.CRM.Application.CRM.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<CoffeeCRM>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Detatils { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CoffeeCRM, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Detatils,
                    opt => opt.MapFrom(note => note.Detatils))
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                    opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
