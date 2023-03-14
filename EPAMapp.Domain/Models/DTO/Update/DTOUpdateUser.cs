using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateUser : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
