using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Acity.Biblioteca.Application.Configuration;
using Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo;
using Acity.Biblioteca.Application.Validators.Prestamo;

namespace Acity.Biblioteca.Application
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());

            #region Prestamo
            services.AddTransient<IRegistroPrestamoCommand, RegistroPrestamoCommand>();

            #endregion 

            #region Validator
            services.AddScoped<IValidator<RegistroPrestamoModel>, RegistroPrestamoValidator>();

            #endregion

            return services;
        }
    }
}
