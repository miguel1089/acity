namespace Acity.Biblioteca.Application.DataBase.LibroCopia.Queries.ObtenerLibroCopia
{
    public class ObtenerLibroCopiaModel
    {
        public int IdLibroCopia { get; set; }
        public int IdLibro { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public bool Activo { get; set; }
    }
}
