using EPAMapp.Domain.Models.Common;

namespace EPAMapp.DAL.Repositories.Interfaces;

public interface IAsyncRepository<T>
    where T : BaseEntity
{
    public Task Create(T entity);        // C - Create
    public IQueryable<T> Get();        // R - Read
    public Task Update(T Item);     // U - Update
    public Task Delete(T item);     // D - Delete

}