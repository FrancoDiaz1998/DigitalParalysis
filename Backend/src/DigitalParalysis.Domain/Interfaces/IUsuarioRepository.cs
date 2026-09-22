using DigitalParalysis.Domain.Entities;

namespace DigitalParalysis.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObtenerPorIdAsync(int id);

    Task<Usuario?> ObtenerPorEmailAsync(string email);

    Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario);

    Task<IReadOnlyList<Usuario>> ObtenerTodosAsync();

    Task AgregarAsync(Usuario usuario);

    Task ActualizarAsync(Usuario usuario);

    Task EliminarAsync(Usuario usuario);
}