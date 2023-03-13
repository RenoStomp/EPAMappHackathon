﻿using EPAMapp.DAL.DataBaseExists;
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
            if (Exist<T>.DataBaseIsNotExist(_context)) return;

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            if(Exist<T>.DataBaseIsNotExist(_context)) return default(IQueryable<T>);

            return _context.Set<T>();
        }
        public T GetById(int id)
        {
            var entity = Get().FirstOrDefault(x => x.Id == id);
            if (Exist<T>.EntityIsNotExist(entity))
                return default(T);

            return entity;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Get().FirstOrDefaultAsync(x => x.Id == id);
            if (Exist<T>.EntityIsNotExist(entity))
                return default(T);

            return entity;
        }

        public async Task Update(T entity)
        {
            if (Exist<T>.DataBaseIsNotExist(_context)) return;

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (Exist<T>.DataBaseIsNotExist(_context)) return;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
