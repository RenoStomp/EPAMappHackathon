using EPAMapp.Domain.Models.Common;

namespace EPAMapp.Domain.Models.Interfaces
{
    public interface IBaseResponse<T> 
    {
        string Description { get; }
        T Data { get; }
    }
}
