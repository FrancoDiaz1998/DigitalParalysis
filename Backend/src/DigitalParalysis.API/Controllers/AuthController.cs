using DigitalParalysis.Application.UseCases.Autenticacion.IniciarSesion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalParalysis.API.Controllers;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public sealed class AuthController : ControllerBase
{
    private readonly IniciarSesionUseCase _iniciarSesion;

    public AuthController(IniciarSesionUseCase iniciarSesion)
    {
        _iniciarSesion = iniciarSesion;
    }

    [HttpPost("login")]
    [ProducesResponseType<IniciarSesionResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IniciarSesionResponse>> Login(IniciarSesionRequest request)
    {
        var response = await _iniciarSesion.EjecutarAsync(request);

        return Ok(response);
    }
}
