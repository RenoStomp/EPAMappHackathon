using EPAMapp.DAL.Repositories.Implementations;
using EPAMapp.DAL.Repositories.Interfaces;
using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.Interfaces;

namespace EPAMapp.API
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<User>, AsyncRepository<User>>();
            services.AddScoped<IAsyncRepository<Note>, AsyncRepository<Note>>();
            services.AddScoped<IAsyncRepository<Admin>, AsyncRepository<Admin>>();
        }
        public static void InitializeServeces(this IServiceCollection services)
        {
            services.AddScoped<IAsyncBaseService>
        }
    }
}
