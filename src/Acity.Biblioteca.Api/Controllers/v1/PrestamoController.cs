using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Acity.Biblioteca.Application.Exceptions;
using Acity.Biblioteca.Application.Features;
using Acity.Biblioteca.Application.DataBase.Prestamo.Commands.RegistroPrestamo;
using Acity.Biblioteca.Application.Util;

namespace Acity.Biblioteca.Api.Controllers.v1
{
    //[Authorize]
    [Route("api/v1/prestamo")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class PrestamoController : ControllerBase
    {
        public PrestamoController()
        {

        }
        /// <summary>
        /// Registra una solicitud de préstamo
        /// </summary>
        /// <remarks>
        /// Descripción:
        /// -
        /// Servicio de tipo POST para registrar una solicitud de tipo préstamo.
        ///
        /// Validaciones:
        /// - Valida si libro existe (IdLibroCopia)
        /// - Valida si hay stock disponible
        /// 
        /// Reglas de negocio:
        /// -
        /// - Se necesita iniciar una sesión en el sistema, este método puede validarse desde el cliente web
        ///
        ///  Códigos de respuesta:
        /// -
        /// - 200 OK : La solicitud se ha realizado correctamente.         
        /// - 401 UNAUTHORIZED: La solicitud no se ha aplicado porque carece de credenciales de autenticación válidas para el recurso de destino.
        /// - 500 INTERNAL SERVER ERROR: El servidor encontró una condición inesperada que le impidió cumplir con la solicitud.
        /// 
        /// </remarks>
        /// <returns>listado de departamentos</returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] RegistroPrestamoModel model,
            [FromServices] IRegistroPrestamoCommand RegistroPrestamoCommand,
            [FromServices] IValidator<RegistroPrestamoModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors, Constantes.MensajesNOOK.M03));
            }
            var data = await RegistroPrestamoCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status201Created, data, Constantes.MensajesOK.M01));
        }

    }
}
