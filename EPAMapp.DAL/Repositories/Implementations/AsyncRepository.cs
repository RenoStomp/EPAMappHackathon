using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.DAL.SqlServer;
using EPAMapp.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.DAL.Repositories.Implementations
{
    public class AsyncRepository<T> : IAsyncRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public AsyncRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            if (DataBaseIsNotExist()) return;

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            if(DataBaseIsNotExist()) return default(IQueryable<T>);

            return _context.Set<T>();
        }

        public async Task Update(T entity)
        {
            if (DataBaseIsNotExist()) return;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (DataBaseIsNotExist()) return;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public bool DataBaseIsNotExist()
        {
            if (_context.Set<T>() == default(DbSet<T>)) 
                return true;

            return false;
        }
    }
}
