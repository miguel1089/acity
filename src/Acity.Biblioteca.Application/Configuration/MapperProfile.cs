using Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo;
using Acity.Biblioteca.Domain.Entities.Solicitud;
using AutoMapper;


namespace Acity.Biblioteca.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            CreateMap<SolicitudEntity, RegistroPrestamoModel>().ReverseMap();
        }
    }
}
