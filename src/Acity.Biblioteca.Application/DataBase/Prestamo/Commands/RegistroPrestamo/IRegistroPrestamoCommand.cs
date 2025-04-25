namespace Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo
{
    public interface IRegistroPrestamoCommand
    {
        Task<long> Execute(RegistroPrestamoModel model);
    }
}
