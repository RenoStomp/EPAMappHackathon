using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.DTO.Create;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.DTO.Update;
using EPAMapp.Services.Interfaces;
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

        public async Task<IBaseResponse<Tmodel>> Create(T model)
        {
            try
            {
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(model)) return new BaseResponse<Tmodel>()
                {
                    Description = "Created entity not found"
                };

                //CreateMapper<Tmodel, DTOCreateBase> mapper = new();
                //Tmodel entity = mapper.Map(model as DTOCreateBase);

                BaseEntity entity = new();
                if (model is DTOCreateUser userModel)
                {
                    User user = new()
                    {
                        Name = userModel.Name,
                        Surname = userModel.Surname,
                        Email = userModel.Email,
                        Password = userModel.Password
                    };
                    entity = user;
                }
                else if (model is DTOCreateNote noteModel)
                {
                    Note note = new()
                    {
                        PastReport = noteModel.PastReport,
                        CurrentReport = noteModel.CurrentReport,
                        NextReport = noteModel.NextReport,
                        UserId = noteModel.UserId
                    };
                    entity = note;
                }
                else if (model is DTOCreateAdmin adminModel)
                {
                    Admin admin = new()
                    {
                        Name = adminModel.Name,
                        Surname = adminModel.Surname,
                        Email = adminModel.Email,
                        Password = adminModel.Password,
                        NickName = adminModel.NickName
                    };
                    entity = admin;
                }
                else
                {
                    return new BaseResponse<Tmodel>
                    {
                        Description = "Entity type not supported for update"
                    };
                }


                await _repository.Create(entity as Tmodel);
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
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(entities)) return new BaseResponse<List<Tmodel>>()
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
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(entities)) return new BaseResponse<List<Tmodel>>()
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
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(entity)) return new BaseResponse<Tmodel>()
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
        public async Task<IBaseResponse<List<Tmodel>>> GetNotesModelsByUserIdAsync(int id)
        {
            try
            {

                var entities = await _repository.GetNotesByUserIdAsync(id).Result.ToListAsync();
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(entities as T)) return new BaseResponse<List<Tmodel>>()
                {
                    Description = "Entity not found"
                };
                return new BaseResponse<List<Tmodel>>()
                {
                    Data = entities as List<Tmodel>
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<Tmodel>>() { Description = e.Message };
            }
        }

        public async Task<IBaseResponse<Tmodel>> Update(T model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync((model as DTOUpdateBase).Id);
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(entity as T))
                {
                    return new BaseResponse<Tmodel>
                    {
                        Description = "Entity to be updated was not found"
                    };
                }

                //UpdateMapper<Tmodel, DTOUpdateBase> mapper = new();
                //entity = mapper.Map(model as DTOUpdateBase);

                if (entity is User user && model is DTOUpdateUser userModel)
                {
                    user.Name = userModel.Name;
                    user.Surname = userModel.Surname;
                    user.Email = userModel.Email;
                    user.Password = userModel.Password;
                }
                else if (entity is Note note && model is DTOUpdateNote noteModel)
                {
                    note.NextReport = noteModel.NextReport;
                    note.PastReport = noteModel.PastReport;
                    note.CurrentReport = noteModel.CurrentReport;
                    note.UserId = noteModel.UserId;
                }
                else if (entity is Admin admin && model is DTOUpdateAdmin adminModel)
                {
                    admin.Name = adminModel.Name;
                    admin.Surname = adminModel.Surname;
                    admin.Email = adminModel.Email;
                    admin.Password = adminModel.Password;
                    admin.NickName = adminModel.NickName;
                }
                else
                {
                    return new BaseResponse<Tmodel>
                    {
                        Description = "Entity type not supported for update"
                    };
                }
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
                if (Exist<Tmodel, T, AccountHolder>.EntityIsNotExist(model)) return new BaseResponse<Tmodel>
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
        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                await _repository.DeleteById(id);
                return new BaseResponse<bool>() { Data = true };

            }
            catch (Exception e)
            {
                return new BaseResponse<bool>() { Description = e.Message };
            }
        }
    }
}
