using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.Interfaces;

namespace EPAMapp.Services.Interfaces
{
    public interface IAsyncLoginService<H> where H : AccountHolder
    {
        public Task<IBaseResponse<H>> Register(H model);
        public Task<IBaseResponse<H>> Login(H model);
    }
}
