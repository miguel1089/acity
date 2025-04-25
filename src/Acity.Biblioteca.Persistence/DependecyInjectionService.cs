using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Acity.Biblioteca.Application.DataBase;
using Acity.Biblioteca.Persistence.Database;


namespace Acity.Biblioteca.Persistence
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["SQLConnectionStrings"]));

            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
