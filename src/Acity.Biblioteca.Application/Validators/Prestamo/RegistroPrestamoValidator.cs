using Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo;
using FluentValidation;


namespace Acity.Biblioteca.Application.Validators.Prestamo
{
    public class RegistroPrestamoValidator: AbstractValidator<RegistroPrestamoModel>
    {
        public RegistroPrestamoValidator() 
        {

            RuleFor(x => x.IdTipo)
                .NotNull().WithMessage("El campo no puede ser nulo.")
                .NotEmpty();

            RuleFor(x => x.IdLibroCopia)
                .NotNull().WithMessage("El campo no puede ser nulo.")
                .NotEmpty();

            RuleFor(x => x.UsuarioCreacion)
                .NotNull().WithMessage("El campo no puede ser nulo.")
                .NotEmpty()
                .MaximumLength(50).WithMessage("El tamaño maximo del campo es de 50 caracteres.");
        }
    }
}
