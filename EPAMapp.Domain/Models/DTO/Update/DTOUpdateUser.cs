using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateUser : Human
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
