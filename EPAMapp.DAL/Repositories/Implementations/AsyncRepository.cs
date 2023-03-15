using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.DAL.SqlServer;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.DAL.Repositories.Implementations
{
    public class AsyncRepository<T,H> : IAsyncRepository<T>, IAsyncLoginRepository<H>
        where T : BaseEntity
        where H : AccountHolder
    {
        private readonly AppDbContext _context;
        public AsyncRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return;

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return default(IQueryable<T>);

            return _context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAsync()
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return default(IQueryable<T>);

            return await Task.FromResult(_context.Set<T>());
        }

        public T GetById(int id)
        {
            var entity = Get().FirstOrDefault(x => x.Id == id);
            if (Exist<T, BaseDTO, H>.EntityIsNotExist(entity))
                return default(T);

            return entity;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await GetAsync().Result.FirstOrDefaultAsync(x => x.Id == id);
            if (Exist<T, BaseDTO, H>.EntityIsNotExist(entity))
                return default(T);

            return entity;
        }
        public async Task<IQueryable<H>> GetAllByMailAsync(string email)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return default(IQueryable<H>);

            return _context.Set<H>();

        }
        public async Task<H> GetByEmailAsync(string email)
        {
            var entity = await GetAllByMailAsync(email).Result.FirstOrDefaultAsync(u => u.Email == email);
            if (Exist<T, BaseDTO, H>.EntityIsNotExist(entity))
                return default(H);

            return entity;
        }
        public async Task<IQueryable<Note>> GetNotesByUserIdAsync(int userId)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return default(IQueryable<Note>);

            return await Task.FromResult(_context.Set<Note>().Where(o => o.UserId == userId));
        }
        public async Task Update(T entity)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            if (Exist<T, BaseDTO, H>.DataBaseIsNotExist(_context))
                return;

            var entity = await GetByIdAsync(id);
            await Delete(entity);
        }

     
    }
}
