namespace EPAMapp.Domain.Models.Common
{
    public abstract class BaseNote : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
