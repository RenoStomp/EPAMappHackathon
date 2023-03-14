using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Entities;

namespace EPAMapp.DAL.Repositories.Interfaces;

public interface IAsyncRepository<T>
    where T : BaseEntity
{
    public Task Create(T entity);           // C - Create
    public IQueryable<T> Get();             // R - Read all
    public Task<IQueryable<T>> GetAsync();  // R - Read all async
    public T GetById(int id);               // R - Read one
    public Task<T> GetByIdAsync(int id);    // R - Read one async
    public Task<IQueryable<Note>> GetNotesByUserIdAsync(int userId); //R - Read notes by user id
    public Task Update(T Item);             // U - Update
    public Task Delete(T item);             // D - Delete

}