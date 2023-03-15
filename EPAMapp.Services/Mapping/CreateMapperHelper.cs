using AutoMapper;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;

namespace EPAMapp.Services.Mapping
{
    public class CreateMapperHelper
    {
        public static Admin MapDtoAdminToAdmin(DTOCreateAdmin dtoCreateAdmin, IMapper mapper)
        {
            return mapper.Map<DTOCreateAdmin, Admin>(dtoCreateAdmin);
        }

        public static Note MapDtoNoteToNote(DTOCreateNote dtoCreateNote, IMapper mapper)
        {
            return mapper.Map<DTOCreateNote, Note>(dtoCreateNote);
        }

        public static User MapDtoUserToUser(DTOCreateUser dtoCreateUser, IMapper mapper)
        {
            return mapper.Map<DTOCreateUser, User>(dtoCreateUser);
        }
    }
}
