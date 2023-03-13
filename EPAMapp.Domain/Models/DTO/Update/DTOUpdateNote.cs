using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateNote : BaseEntity
    {
        public string Report { get; set; }
        public int UserId { get; set; }

    }
}
