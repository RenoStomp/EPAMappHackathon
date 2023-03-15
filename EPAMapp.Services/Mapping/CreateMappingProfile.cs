using AutoMapper;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;

namespace EPAMapp.Services.Mapping
{
    public class CreateMappingProfile : Profile
    {
        public CreateMappingProfile()
        {
            ConfigureDTOUpdateUserMap();
            ConfigureDTOUpdateAdminMap();
            ConfigureDTOUpdateNoteMap();
        }
        private void ConfigureDTOUpdateUserMap()
        {
            CreateMap<DTOCreateUser, User>()
                .ForMember(dest => dest.Notes, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }

        private void ConfigureDTOUpdateAdminMap()
        {
            CreateMap<DTOCreateAdmin, Admin>()
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }

        private void ConfigureDTOUpdateNoteMap()
        {
            CreateMap<DTOCreateNote, Note>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PastReport, opt => opt.MapFrom(src => src.PastReport))
                .ForMember(dest => dest.CurrentReport, opt => opt.MapFrom(src => src.CurrentReport))
                .ForMember(dest => dest.NextReport, opt => opt.MapFrom(src => src.NextReport))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());


        }

    }
}
