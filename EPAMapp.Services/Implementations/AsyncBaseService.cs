using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.Interfaces;
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
                if (EntityIsNotExist(model)) return new BaseResponse<T>()
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
                if (EntityIsNoExist(entities)) return new BaseResponse<List<T>>()
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

        public IBaseResponse<T> GetById(int id)
        {
            try
            {
                var entity = GetEntityById(id);
                if (EntityIsNotExist(entity)) return new BaseResponse<T>()
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
                var entity = await GetEntityByIdAsync(model.Id);
                if (EntityIsNotExist(entity)) return new BaseResponse<T>
                {
                    Description = "Entity to be updated was not found"
                };

                if(typeof(T) == typeof(User))
                {
                    User? _user = entity as User;
                    User? _model = entity as User;
                    _user.Name = _model.Name;
                    _user.Surname = _model.Surname;
                    _user.Email = _model.Email;
                    _user.Password = _model.Password;
                }
                if(typeof(T) == typeof(Note))
                {
                    Note? _note = entity as Note;
                    Note? _model = entity as Note;
                    _note.Report = _model.Report;
                    _note.UserId = _model.UserId;
                }
                if(typeof(T) == typeof(Admin))
                {
                    Admin? _admin = entity as Admin;
                    Admin? _model = entity as Admin;
                    _admin.Name = _model.Name;
                    _admin.Surname = _model.Surname;
                    _admin.Email = _model.Email;
                    _admin.Password = _model.Password;
                    _admin.NickName = _model.NickName;
                }
                if(EntityIsNotExist(entity)) return new BaseResponse<T>
                {
                    Description = "Entity not update"
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
                if (EntityIsNotExist(model)) return new BaseResponse<T>
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
        public T GetEntityById(int id)
        {
           var entity = _repository.Get().FirstOrDefault(x => x.Id == id);
           if (EntityIsNotExist(entity)) 
                return default(T);
            
           return entity;           
        }
        public async Task<T> GetEntityByIdAsync(int id)
        {
            var entity = await _repository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (EntityIsNotExist(entity)) 
                return default(T);

            return entity;

        }
        public bool EntityIsNotExist(T entity)
        {
            if (entity == null)
                return true;

            return false;
        }
        public bool EntityIsNoExist(List<T> entities)
        {
            if (entities == null || !entities.Any())
                return true;

            return false;
        }
    }
}
