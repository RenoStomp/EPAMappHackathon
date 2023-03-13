using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateAdmin : Human
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
    }
}
