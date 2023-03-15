using EPAMapp.DAL.DataBaseExists;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Helpers;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Domain.Models.Interfaces;
using EPAMapp.Domain.Models.Response;
using EPAMapp.Services.Interfaces;
using EPAMapp.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.Services.Implementations
{
    public class AsyncLoginService<H, Tmodel> : IAsyncLoginService<H>
        where H : AccountHolder
        where Tmodel : BaseEntity 
    {
        private readonly IAsyncLoginRepository<H> _repositoryLogin;
        private readonly IAsyncRepository<Tmodel> _repository;


        public AsyncLoginService(IAsyncLoginRepository<H> repositoryLogin, IAsyncRepository<Tmodel> repository)
        {
            _repositoryLogin = repositoryLogin;
            _repository = repository;
        }
      
        public async Task<IBaseResponse<H>> Register(H model)
        {
            try
            {
                var existingUser = await _repositoryLogin.GetByMailAsync(model.Email);
                if (Exist<BaseEntity, BaseDTO, H>.EntityIsNotExist(existingUser)) return new BaseResponse<H>()
                {
                    Description = "Пользователь с таким email уже зарегистрирован."
                 
                };

                CreateMapper<Tmodel, DTOCreateBase> mapper = new();
                Tmodel user = mapper.Map(model as DTOCreateBase);


                await _repository.Create(user);
                return new BaseResponse<H>()
                {
                    Data = model
                };
            }
            catch (Exception e)
            {

                return new BaseResponse<H>() { Description = e.Message };
            }


        }

        public async Task<IBaseResponse<H>> Login(H model)
        {
            try
            {
                // Получаем пользователя из базы данных по email
                var user = await _repositoryLogin.GetByMailAsync(model.Email);
                if (Exist<BaseEntity, BaseDTO, H>.EntityIsNotExist(user)) return new BaseResponse<H>()
                {
                    Description = "Пользователь с таким email уже зарегистрирован."
                };

                // Проверяем, что пароль пользователя совпадает с введенным паролем
                if (user.Password != HashPasswordHelper.HashPassword(model.Password)) return new BaseResponse<H>()
                {
                    Description = "Неправильный пароль."
                };

                return new BaseResponse<H>()
                {
                    Data = user
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<H>() { Description = e.Message };
            }

        }
    }
}
