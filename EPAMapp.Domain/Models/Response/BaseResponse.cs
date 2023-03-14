using EPAMapp.Domain.Models.Interfaces;

namespace EPAMapp.Domain.Models.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public T Data { get; set; }
    }
}
