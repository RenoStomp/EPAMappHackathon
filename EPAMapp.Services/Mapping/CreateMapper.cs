using AutoMapper;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Services.DTO.Update;

namespace EPAMapp.Services.Mapping
{
    public class CreateMapper<T, TModel>
        where T : BaseEntity
        where TModel : DTOCreateBase
    {
        private readonly IMapper _mapper;

        public CreateMapper()
        {
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AddProfile(new CreateMappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        public T? Map(TModel model)
        {
            return model switch
            {
                DTOCreateUser userModel => CreateMapperHelper.MapDtoUserToUser(userModel, _mapper) as T,
                DTOCreateAdmin adminModel => CreateMapperHelper.MapDtoAdminToAdmin(adminModel, _mapper) as T,
                DTOCreateNote noteModel => CreateMapperHelper.MapDtoNoteToNote(noteModel, _mapper) as T,

                _ => default(T)
            };
        }

    }
}
