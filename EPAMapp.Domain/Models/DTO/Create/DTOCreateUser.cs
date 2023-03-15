using EPAMapp.Domain.Models.DTO.Common;

namespace EPAMapp.Domain.Models.DTO.Create
{
    public class DTOCreateUser : DTOCreateBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
