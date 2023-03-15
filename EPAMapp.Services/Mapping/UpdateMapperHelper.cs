using AutoMapper;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;

namespace EPAMapp.Services.Mapping
{
    public static class UpdateMapperHelper
    {
        public static Admin MapDtoAdminToAdmin(DTOUpdateAdmin dtoUpdateAdmin, IMapper mapper)
        {
            return mapper.Map<DTOUpdateAdmin, Admin>(dtoUpdateAdmin);
        }

        public static Note MapDtoNoteToNote(DTOUpdateNote dtoUpdateNote, IMapper mapper)
        {
            return mapper.Map<DTOUpdateNote, Note>(dtoUpdateNote);
        }

        public static User MapDtoUserToUser(DTOUpdateUser dtoUpdateUser, IMapper mapper)
        {
            return mapper.Map<DTOUpdateUser, User>(dtoUpdateUser);
        }
    }
}
