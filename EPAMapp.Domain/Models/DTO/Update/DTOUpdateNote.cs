using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateNote : BaseEntity
    {
        public string PastReport { get; set; }
        public string CurrentReport { get; set; }
        public string NextReport { get; set; }
        public int UserId { get; set; }

    }
}
