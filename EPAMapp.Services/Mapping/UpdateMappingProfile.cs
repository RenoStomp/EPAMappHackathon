using AutoMapper;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;

namespace EPAMapp.Services.Mapping
{
    public class UpdateMappingProfile : Profile
    {

        public UpdateMappingProfile()
        {
            ConfigureDTOUpdateUserMap();
            ConfigureDTOUpdateAdminMap();
            ConfigureDTOUpdateNoteMap();
        }
        private void ConfigureDTOUpdateUserMap()
        {
            CreateMap<DTOUpdateUser, User>()
                .ForMember(dest => dest.Notes, opt => opt.Ignore()) // Ignore the Notes property;
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }

        private void ConfigureDTOUpdateAdminMap()
        {
            CreateMap<DTOUpdateAdmin, Admin>()
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }

        private void ConfigureDTOUpdateNoteMap()
        {
            CreateMap<DTOUpdateNote, Note>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PastReport, opt => opt.MapFrom(src => src.PastReport))
                .ForMember(dest => dest.CurrentReport, opt => opt.MapFrom(src => src.CurrentReport))
                .ForMember(dest => dest.NextReport, opt => opt.MapFrom(src => src.NextReport))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore the User property;
        }
    }
}
