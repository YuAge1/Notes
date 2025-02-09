using AutoMapper;
using CRM.Application.Common.Mappings;
using CRM.Application.CRM.Application.CRM.Commands.CreateCRM;
using CRM.Application.CRM.Application.CRM.Commands.UpdateCRM;

namespace CRM.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateCRMCommand>
    {
        private Guid Id { get; set; }
        private string Title { get; set; }
        private string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateCRMCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
