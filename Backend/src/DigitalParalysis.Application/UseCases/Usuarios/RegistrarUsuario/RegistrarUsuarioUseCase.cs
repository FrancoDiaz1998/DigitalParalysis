using DigitalParalysis.Application.Interfaces;
using DigitalParalysis.Domain.Entities;
using DigitalParalysis.Domain.Interfaces;
using DigitalParalysis.Application.Common.Exceptions;

namespace DigitalParalysis.Application.UseCases.Usuarios.RegistrarUsuario;

public class RegistrarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegistrarUsuarioUseCase(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegistrarUsuarioResponse> EjecutarAsync(RegistrarUsuarioRequest request)
    {
        // 1) Verificar email
        var usuarioExistente = await _usuarioRepository.ObtenerPorEmailAsync(request.Email);

        if (usuarioExistente is not null)
        {
            throw new RecursoDuplicadoException("Ya existe un usuario registrado con ese email.");
        }

        // 2) Verificar contraseña y hashear
        if (string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentException("La contraseña es obligatoria.");
        }

        if (request.Password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        if (request.Password.Length > 128)
        {
            throw new ArgumentException("La contraseña no puede superar los 128 caracteres.");
        }

        var hash = _passwordHasher.Hash(request.Password);

        // 3) Crear entidad
        var usuario = new Usuario(
            request.Nombre,
            request.Apellido,
            request.NombreUsuario,
            request.Email,
            hash,
            request.FechaNacimiento);

        // 4) Guardar
        await _usuarioRepository.AgregarAsync(usuario);

        // 5) Responder
        return new RegistrarUsuarioResponse
        {
            Id = usuario.Id,
            NombreUsuario = usuario.NombreUsuario
        };
    }
}