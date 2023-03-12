using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Domain.Models.Entities
{
    public class Note : BaseEntity
    {
        public string Report { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
