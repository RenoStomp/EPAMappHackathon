using AutoMapper;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Mapping;

namespace EPAMapp.Services.Update
{
    public class UpdateMapper<T, TModel>
        where T : BaseEntity
        where TModel : DTOUpdateBase
    {
        private readonly IMapper _mapper;

        public UpdateMapper()
        {
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AddProfile(new UpdateMappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        public T? Map(TModel model)
        {
            return model switch
            {
                DTOUpdateUser userModel => UpdateMapperHelper.MapDtoUserToUser(userModel, _mapper) as T,
                DTOUpdateAdmin adminModel => UpdateMapperHelper.MapDtoAdminToAdmin(adminModel, _mapper) as T,
                DTOUpdateNote noteModel => UpdateMapperHelper.MapDtoNoteToNote(noteModel, _mapper) as T,

                _ => default(T)
            };
        }

    }
}
