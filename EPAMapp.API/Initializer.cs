using EPAMapp.DAL.Repositories.Implementations;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Common;
using EPAMapp.Domain.Models.DTO.Common;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.Implementations;
using EPAMapp.Services.Interfaces;

namespace EPAMapp.API
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<User>, AsyncRepository<User, AccountHolder>>();
            services.AddScoped<IAsyncRepository<Note>, AsyncRepository<Note, AccountHolder>>();
            services.AddScoped<IAsyncRepository<Admin>, AsyncRepository<Admin, AccountHolder>>();
        }
        public static void InitializeServeces(this IServiceCollection services)
        {
            services.AddScoped<IAsyncBaseService<BaseDTO, User>, AsyncBaseService<BaseDTO, User>>();
            services.AddScoped<IAsyncBaseService<BaseDTO, Note>, AsyncBaseService<BaseDTO, Note>>();
            services.AddScoped<IAsyncBaseService<BaseDTO, Admin>, AsyncBaseService<BaseDTO, Admin>>();

        }
    }
}
