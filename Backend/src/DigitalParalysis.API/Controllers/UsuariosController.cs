using System.IdentityModel.Tokens.Jwt;
using DigitalParalysis.Application.UseCases.Usuarios.RegistrarUsuario;
using DigitalParalysis.Application.UseCases.Usuarios.ObtenerUsuariosPorId;
using DigitalParalysis.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalParalysis.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly RegistrarUsuarioUseCase _registrarUsuario;
    private readonly ObtenerUsuarioIdUseCase _obtenerUsuarioId;

    public UsuariosController(RegistrarUsuarioUseCase registrarUsuario, ObtenerUsuarioIdUseCase obtenerUsuarioIdUseCase)
    {
        _registrarUsuario = registrarUsuario;
        _obtenerUsuarioId = obtenerUsuarioIdUseCase;
    }

    [Authorize(Roles = nameof(RolUsuario.Admin))]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var respuesta = await _obtenerUsuarioId.EjecutarAsync(id);

        return respuesta is null ? NotFound() : Ok(respuesta);
       
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> ObtenerMiPerfil()
    {
        var subject = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (!int.TryParse(subject, out var usuarioId))
        {
            return Unauthorized();
        }

        var respuesta = await _obtenerUsuarioId.EjecutarAsync(usuarioId);

        return respuesta is null ? NotFound() : Ok(respuesta);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Registrar(RegistrarUsuarioRequest request)
    {
        var respuesta = await _registrarUsuario.EjecutarAsync(request);

        return CreatedAtAction(nameof(ObtenerPorId), new { id = respuesta.Id }, respuesta);
    }
}
