namespace Acity.Biblioteca.Application.DataBase.Libro.Queries.ObtenerLibro
{
    public class ObtenerLibroModel
    {
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
    }
}
