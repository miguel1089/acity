using Microsoft.AspNetCore.Mvc;
using Acity.Biblioteca.Application.Exceptions;
using Acity.Biblioteca.Application.External.GetTokenJwt;
using Acity.Biblioteca.Application.Features;

namespace Acity.Biblioteca.Api.Controllers.v1
{
    [Route("api/v1/seguridad")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class SeguridadController : ControllerBase
    {

        [HttpGet("get-token")]
        public async Task<IActionResult> getToken([FromServices] IGetTokenJwtService getTokenJwtService)
        {
            var idUsuario = 1;
            var token = getTokenJwtService.Execute(idUsuario.ToString());
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, token));

        }

    }
}
