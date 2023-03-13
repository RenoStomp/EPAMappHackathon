using AutoMapper;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Mapping;

namespace EPAMapp.Services.Update
{
    public class Mapper<T, TModel>
        where T : BaseEntity
        where TModel : BaseEntity
    {
        private readonly IMapper _mapper;

        public Mapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        public T? Map(TModel model)
        {
            return model switch
            {
                DTOUpdateUser userModel => MapperHelper.MapDtoUserToUser(userModel, _mapper) as T,
                DTOUpdateAdmin adminModel => MapperHelper.MapDtoAdminToAdmin(adminModel, _mapper) as T,
                DTOUpdateNote noteModel => MapperHelper.MapDtoNoteToNote(noteModel, _mapper) as T,
                _ => default(T)
            };
        }

    }
}
