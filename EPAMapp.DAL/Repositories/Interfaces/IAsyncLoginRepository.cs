using EPAMapp.Domain.Models.Common;

namespace EPAMapp.DAL.Repositories.Interfaces
{
    public interface IAsyncLoginRepository<H> where H : AccountHolder
    {

        public Task<IQueryable<H>> GetAllByEmailAsync(string email);    // R - Read one by mail async
        public Task<H> GetByMailAsync(string email);  // R - Read all by mail async

    }
}
