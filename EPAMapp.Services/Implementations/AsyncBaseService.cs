using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Interfaces;
using EPAMapp.Services.Update;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.Services.Implementations
{
    public class AsyncBaseService<T> : IAsyncBaseService<T> where T : BaseEntity
    {
        private readonly IAsyncRepository<T> _repository;

        public AsyncBaseService(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IBaseResponse<T>> Create(T model)
        {
            try
            {
                if (Exist<T>.EntityIsNotExist(model)) return new BaseResponse<T>()
                {
                    Description = "Created entity not found"
                };
                await _repository.Create(model);
                return new BaseResponse<T>()
                {
                    Data = model
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<T>() { Description = e.Message };
            }
        }

        public IBaseResponse<List<T>> GetAll()
        {
            try
            {
                var entities = _repository.Get().ToList();
                if (Exist<T>.EntityIsNoExist(entities)) return new BaseResponse<List<T>>()
                {
                    Description = "Entities not found"
                };

                return new BaseResponse<List<T>>()
                {
                    Data = entities
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<T>>() { Description = e.Message };
            }
        }
        public async Task<IBaseResponse<List<T>>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.Get().ToListAsync();
                if (Exist<T>.EntityIsNoExist(entities)) return new BaseResponse<List<T>>()
                {
                    Description = "Entities not found"
                };

                return new BaseResponse<List<T>>()
                {
                    Data = entities
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<T>>() { Description = e.Message };
            }
        }

        public IBaseResponse<T> GetModelById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                if (Exist<T>.EntityIsNotExist(entity)) return new BaseResponse<T>()
                {
                    Description = "Entity not found"
                };

                return new BaseResponse<T>()
                {
                    Data = entity
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IBaseResponse<T>> Update(T model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id);
                if (Exist<T>.EntityIsNotExist(entity))
                {
                    return new BaseResponse<T>
                    {
                        Description = "Entity to be updated was not found"
                    };
                }

                if (entity is User user && model is DTOUpdateUser userModel)
                    await UpdateUser.Update(user, userModel);
                
                else if (entity is Note note && model is DTOUpdateNote noteModel)
                    await UpdateNote.Update(note, noteModel);
                
                else if (entity is Admin admin && model is DTOUpdateAdmin adminModel)
                    await UpdateAdmin.Update(admin, adminModel);

                else
                    return new BaseResponse<T>
                    {
                        Description = "Entity type not supported for update"
                    };
                

                await _repository.Update(entity);
                return new BaseResponse<T>()
                {
                    Data = entity
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<T>() { Description = e.Message };
            }
        }

        public async Task<IBaseResponse<T>> Delete(T model)
        {
            try
            {
                if (Exist<T>.EntityIsNotExist(model)) return new BaseResponse<T>
                {
                    Description = "Entity to be deleted was not found "
                };

                await _repository.Delete(model);
                return new BaseResponse<T>()
                {
                    Data = model
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<T>() { Description = e.Message };
            }
        }

        public  async Task DeleteById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await Delete(entity);
        }
    }
}
