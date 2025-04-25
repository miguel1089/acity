using Microsoft.EntityFrameworkCore;
using Acity.Biblioteca.Domain.Entities.Solicitud;
using Acity.Biblioteca.Domain.Entities.Libro;
using Acity.Biblioteca.Domain.Entities.LibroCopia;

namespace Acity.Biblioteca.Application.DataBase
{
    public interface IDataBaseService
    {
        public DbSet<LibroEntity> Libro { get; set; }
        public DbSet<LibroCopiaEntity> LibroCopia { get; set; }
        public DbSet<SolicitudEntity> Solicitud { get; set; }
        Task<bool> SaveAsync();
    }
}
