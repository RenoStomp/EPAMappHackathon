using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.SqlServer;
using EPAMapp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.DAL.Repositories.Implementations
{
    public class AsyncNoteRepository<T> : AsyncRepository<T>
    where T : Note
    {
        public AsyncNoteRepository(AppDbContext context) : base(context) {}

        public async Task<IQueryable<Note>> GetNotesByUserId(int userId)
        {
            if (Exist<T>.DataBaseIsNotExist(_context))
                return default(IQueryable<T>);

            return await Task.FromResult(_context.Set<Note>().Where(o => o.UserId == userId));
        }
    }
}
