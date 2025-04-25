using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acity.Biblioteca.Domain.Entities.Solicitud
{
    public class SolicitudEntity
    {
        [Key]
        public long IdSolicitud { get; set; }
        public int IdTipo { get; set; }
        public int IdEstado { get; set; }
        public long IdLibroCopia { get; set; }
        public bool Activo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
