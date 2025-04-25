using System.ComponentModel.DataAnnotations;

namespace Acity.Biblioteca.Domain.Entities.LibroCopia
{
    public class LibroCopiaEntity
    {
        [Key]
        public long IdLibroCopia { get; set; }
        public int IdLibro { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public bool Activo { get; set; }


    }
}
