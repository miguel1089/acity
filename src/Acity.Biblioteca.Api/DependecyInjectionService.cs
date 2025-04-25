using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Acity.Biblioteca.Api
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(opctions =>
            {
                opctions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version= "v1",
                    Title= "Acity biblioteca Api",
                    Description="Utilización de APIs para Biblioteca App"
                });
                opctions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Ingrese un tpoken válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });
                opctions.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference 
                            {
                               Type= ReferenceType.SecurityScheme,
                               Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opctions.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
            });
            return services;
        }
    }
}
