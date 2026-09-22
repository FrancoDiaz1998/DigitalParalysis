using DigitalParalysis.Domain.Interfaces;

namespace DigitalParalysis.Application.UseCases.Usuarios.ObtenerUsuariosPorId;

public class ObtenerUsuarioIdUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObtenerUsuarioIdUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ObtenerUsuarioIdResponse?> EjecutarAsync(int id)
    {
        var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

        if (usuario is null)
        {
            return null;
        }

        return new ObtenerUsuarioIdResponse
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email,
            FechaNacimiento = usuario.FechaNacimiento,
            Foto = usuario.Foto,
            Rol = usuario.Rol,
            Estado = usuario.Estado,
            FechaRegistro = usuario.FechaRegistro,
            FechaFinSuspension = usuario.FechaFinSuspension,
            FechaEliminacion = usuario.FechaEliminacion
        };
    }
}
