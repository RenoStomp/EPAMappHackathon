using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Interfaces;

namespace EPAMapp.Services.Interfaces
{
    public interface IAsyncLoginService<H, T> 
        where H : AccountHolder
        where T : DTOAccountHolder
    {
        public Task<IBaseResponse<H>> Register(T model);
        public Task<IBaseResponse<H>> Login(T model);
    }
}
