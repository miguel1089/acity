namespace Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo
{
    public class RegistroPrestamoModel
    {
        public int IdTipo { get; set; }
        public long IdLibroCopia { get; set; }
        public bool Activo { get; set; }
        public string? UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
