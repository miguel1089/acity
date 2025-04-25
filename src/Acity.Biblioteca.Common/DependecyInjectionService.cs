using Microsoft.Extensions.DependencyInjection;

namespace Acity.Biblioteca.Common
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
