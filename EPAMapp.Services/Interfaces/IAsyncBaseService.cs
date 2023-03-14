using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.Interfaces;

namespace EPAMapp.Services.Interfaces
{
    public interface IAsyncBaseService<T> where T : BaseEntity
    {
       public Task<IBaseResponse<T>> Create(T model);       //C - Create
       public IBaseResponse<List<T>> GetAll();              //R - Read all
       public Task<IBaseResponse<List<T>>> GetAllAsync();   //R - Read all async
       public IBaseResponse<T> GetModelById(int id);        //R - Read one
       public Task<IBaseResponse<T>> Update(T model);       //U - Update
       public Task<IBaseResponse<T>> Delete( T model);      //D - Delete

    }
}
