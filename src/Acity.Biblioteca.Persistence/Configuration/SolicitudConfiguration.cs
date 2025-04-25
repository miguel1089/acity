using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Acity.Biblioteca.Domain.Entities.Solicitud;

namespace Acity.Biblioteca.Persistence.Configuration
{
    public class SolicitudConfiguration
    {
        public SolicitudConfiguration(EntityTypeBuilder<SolicitudEntity> entityBuilder) 
        {
            entityBuilder.HasKey(x => x.IdSolicitud);
            entityBuilder.Property(x=> x.IdTipo).IsRequired();
            entityBuilder.Property(x => x.IdLibroCopia).IsRequired();
            entityBuilder.Property(x => x.Activo).IsRequired();
            entityBuilder.Property(x => x.UsuarioCreacion).IsRequired();
            entityBuilder.Property(x => x.FechaCreacion).IsRequired();
        }
    }
}
