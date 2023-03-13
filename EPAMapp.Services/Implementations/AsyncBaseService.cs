using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.Interfaces;

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

                if (entity is User user && model is User userModel)
                {
                    user.Name = userModel.Name;
                    user.Surname = userModel.Surname;
                    user.Email = userModel.Email;
                    user.Password = userModel.Password;
                }
                else if (entity is Note note && model is Note noteModel)
                {
                    note.Report = noteModel.Report;
                    note.UserId = noteModel.UserId;
                }
                else if (entity is Admin admin && model is Admin adminModel)
                {
                    admin.Name = adminModel.Name;
                    admin.Surname = adminModel.Surname;
                    admin.Email = adminModel.Email;
                    admin.Password = adminModel.Password;
                    admin.NickName = adminModel.NickName;
                }
                else
                {
                    return new BaseResponse<T>
                    {
                        Description = "Entity type not supported for update"
                    };
                }

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
    }
}
