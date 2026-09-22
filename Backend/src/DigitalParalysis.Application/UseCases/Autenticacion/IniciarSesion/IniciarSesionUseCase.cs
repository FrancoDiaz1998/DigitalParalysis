using DigitalParalysis.Application.Common.Exceptions;
using DigitalParalysis.Application.Interfaces;
using DigitalParalysis.Domain.Enums;
using DigitalParalysis.Domain.Interfaces;

namespace DigitalParalysis.Application.UseCases.Autenticacion.IniciarSesion;

public sealed class IniciarSesionUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public IniciarSesionUseCase(
        IUsuarioRepository usuarioRepository,
        IPasswordHasher passwordHasher,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<IniciarSesionResponse> EjecutarAsync(
        IniciarSesionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            throw new CredencialesInvalidasException();
        }

        var usuario = await _usuarioRepository.ObtenerPorEmailAsync(request.Email);

        if (usuario is null ||
            !_passwordHasher.Verify(request.Password, usuario.ContrasenaHash))
        {
            throw new CredencialesInvalidasException();
        }

        if (usuario.Estado != EstadoUsuario.Activo)
        {
            throw new CuentaNoDisponibleException(
                "La cuenta no está habilitada para iniciar sesión.");
        }

        var accessToken = _accessTokenGenerator.Generate(usuario);

        return new IniciarSesionResponse
        {
            AccessToken = accessToken.Value,
            ExpiresAtUtc = accessToken.ExpiresAtUtc,
            UsuarioId = usuario.Id,
            NombreUsuario = usuario.NombreUsuario,
            Rol = usuario.Rol.ToString()
        };
    }
}
