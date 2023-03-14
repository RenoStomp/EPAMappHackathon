using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;

namespace EPAMapp.Services.DTO.Update
{
    public class DTOUpdateNote : BaseDTO
    {
        public string PastReport { get; set; }
        public string CurrentReport { get; set; }
        public string NextReport { get; set; }
        public int UserId { get; set; }

    }
}
