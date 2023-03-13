using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Domain.Models.Entities
{
    public class Note : BaseEntity
    {
        public string PastReport { get; set; }
        public string CurrentReport { get; set; }
        public string NextReport { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
