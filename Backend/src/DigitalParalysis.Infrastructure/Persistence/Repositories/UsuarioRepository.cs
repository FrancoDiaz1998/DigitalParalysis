using DigitalParalysis.Domain.Entities;
using DigitalParalysis.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalParalysis.Infrastructure.Persistence.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly DigitalParalysisDbContext _dbContext;

    public UsuarioRepository(DigitalParalysisDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        return _dbContext.Usuarios
            .AsNoTracking()
            .SingleOrDefaultAsync(usuario => usuario.Id == id);
    }

    public Task<Usuario?> ObtenerPorEmailAsync(string email)
    {
        var emailNormalizado = email.Trim().ToLowerInvariant();

        return _dbContext.Usuarios
            .AsNoTracking()
            .SingleOrDefaultAsync(usuario => usuario.Email == emailNormalizado);
    }

    public Task<Usuario?> ObtenerPorNombreUsuarioAsync(string nombreUsuario)
    {
        return _dbContext.Usuarios
            .AsNoTracking()
            .SingleOrDefaultAsync(usuario => usuario.NombreUsuario == nombreUsuario);
    }

    public async Task<IReadOnlyList<Usuario>> ObtenerTodosAsync()
    {
        return await _dbContext.Usuarios
            .AsNoTracking()
            .OrderBy(usuario => usuario.Id)
            .ToListAsync();
    }

    public async Task AgregarAsync(Usuario usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Usuario usuario)
    {
        _dbContext.Usuarios.Update(usuario);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EliminarAsync(Usuario usuario)
    {
        _dbContext.Usuarios.Remove(usuario);
        await _dbContext.SaveChangesAsync();
    }
}
