using EPAMapp.Domain.Models.Common;

namespace EPAMapp.DAL.Repositories.Interfaces;

public interface IAsyncRepository<T>
    where T : BaseEntity
{
    public Task Create(T entity);        // C - Create
    public IQueryable<T> Get();          // R - Read all
    public T GetById(int id);            // R - Read one
    public Task<T> GetByIdAsync(int id); // R - Read one async
    public Task Update(T Item);          // U - Update
    public Task Delete(T item);          // D - Delete

}