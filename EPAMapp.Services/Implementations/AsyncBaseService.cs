using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.Interfaces;
using EPAMapp.Services.Update;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.Services.Implementations
{
    public class AsyncBaseService<T, Tmodel> : IAsyncBaseService<T, Tmodel> 
        where T : BaseDTO
        where Tmodel : BaseEntity
    {
        private readonly IAsyncRepository<Tmodel> _repository;

        public AsyncBaseService(IAsyncRepository<Tmodel> repository)
        {
            _repository = repository;
        }
        //TODO: create DTOCREATE
        public async Task<IBaseResponse<Tmodel>> Create(T model)
        {//TODO: Map DTOCREATE on BaseEntity
            try
            {
                if (Exist<Tmodel, T>.EntityIsNotExist(model)) return new BaseResponse<Tmodel>()
                {
                    Description = "Created entity not found"
                };
                await _repository.Create(model);
                return new BaseResponse<Tmodel>()
                {
                    Data = model as Tmodel
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Tmodel>() { Description = e.Message };
            }
        }

        public IBaseResponse<List<Tmodel>> GetAll()
        {
            try
            {
                var entities = _repository.Get().ToList();
                if (Exist<Tmodel, T>.EntityIsNoExist(entities)) return new BaseResponse<List<Tmodel>>()
                {
                    Description = "Entities not found"
                };

                return new BaseResponse<List<Tmodel>>()
                {
                    Data = entities
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<Tmodel>>() { Description = e.Message };
            }
        }
        public async Task<IBaseResponse<List<Tmodel>>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAsync().Result.ToListAsync();
                if (Exist<Tmodel, T>.EntityIsNoExist(entities)) return new BaseResponse<List<Tmodel>>()
                {
                    Description = "Entities not found"
                };

                return new BaseResponse<List<Tmodel>>()
                {
                    Data = entities
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<Tmodel>>() { Description = e.Message };
            }
        }

        public IBaseResponse<Tmodel> GetModelById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);
                if (Exist<Tmodel, T>.EntityIsNotExist(entity)) return new BaseResponse<Tmodel>()
                {
                    Description = "Entity not found"
                };

                return new BaseResponse<Tmodel>()
                {
                    Data = entity
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Tmodel>() { Description = e.Message };
            }
        }
        public async Task<IBaseResponse<Tmodel>> GetNotesModelsByUserIdAsync(int id)
        {
            try
            {
                
                var entities = await _repository.GetNotesByUserIdAsync(id).Result.ToListAsync();
                if (Exist<Tmodel, T>.EntityIsNotExist(entities as T)) return new BaseResponse<Tmodel>()
                {
                    Description = "Entity not found"
                };
                return new BaseResponse<Tmodel>()
                {
                    Data = entities as Tmodel
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Tmodel>() { Description = e.Message };
            }
        }

        public async Task<IBaseResponse<Tmodel>> Update(T model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id);
                if (Exist<Tmodel, T>.EntityIsNotExist(entity as T))
                {
                    return new BaseResponse<Tmodel>
                    {
                        Description = "Entity to be updated was not found"
                    };
                }

                Mapper<Tmodel, T> mapper = new();
                entity = mapper.Map(model) as Tmodel;

                await _repository.Update(entity);
                return new BaseResponse<Tmodel>()
                {
                    Data = entity
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Tmodel>() { Description = e.Message };
            }
        }

        public async Task<IBaseResponse<Tmodel>> Delete(T model)
        {
            try
            {
                if (Exist<Tmodel, T>.EntityIsNotExist(model)) return new BaseResponse<Tmodel>
                {
                    Description = "Entity to be deleted was not found "
                };

                await _repository.Delete(model as Tmodel);
                return new BaseResponse<Tmodel>()
                {
                    Data = model as Tmodel
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<Tmodel>() { Description = e.Message };
            }
        }

        public  async Task DeleteById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await Delete(entity as T);
        }
    }
}
