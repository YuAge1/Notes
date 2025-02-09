using AutoMapper;
using CRM.Application.Common.Mappings;
using CRM.Application.CRM.Application.CRM.Commands.CreateCRM;

namespace CRM.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateCRMCommand>
    {
        private string Title { get; set; }
        private string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateCRMCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
