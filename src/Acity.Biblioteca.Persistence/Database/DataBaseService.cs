using Microsoft.EntityFrameworkCore;
using Acity.Biblioteca.Application.DataBase;
using Acity.Biblioteca.Persistence.Configuration;
using Acity.Biblioteca.Domain.Entities.Solicitud;
using Acity.Biblioteca.Domain.Entities.Libro;
using Acity.Biblioteca.Domain.Entities.LibroCopia;

namespace Acity.Biblioteca.Persistence.Database
{
    public class DataBaseService: DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<LibroEntity> Libro { get; set; }
        public DbSet<LibroCopiaEntity> LibroCopia { get; set; }
        public DbSet<SolicitudEntity> Solicitud { get; set; }
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new SolicitudConfiguration(modelBuilder.Entity<SolicitudEntity>());
        }
    }
}
