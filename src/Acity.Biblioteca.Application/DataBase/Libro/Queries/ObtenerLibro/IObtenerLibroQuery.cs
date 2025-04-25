namespace Acity.Biblioteca.Application.DataBase.Libro.Queries.ObtenerLibro
{
    public interface IObtenerLibroQuery
    {
        Task<List<ObtenerLibroModel>> Execute(int idLibro);
    }
}
