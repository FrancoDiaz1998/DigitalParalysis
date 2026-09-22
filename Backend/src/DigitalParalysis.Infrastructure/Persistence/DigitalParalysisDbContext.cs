using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalParalysis.Infrastructure.Persistence;

public sealed class DigitalParalysisDbContext : DbContext
{
    public DigitalParalysisDbContext(DbContextOptions<DigitalParalysisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Actor> Actores => Set<Actor>();
    public DbSet<Articulo> Articulos => Set<Articulo>();
    public DbSet<Coleccion> Colecciones => Set<Coleccion>();
    public DbSet<Comentario> Comentarios => Set<Comentario>();
    public DbSet<Director> Directores => Set<Director>();
    public DbSet<EstadoUsuario> EstadosUsuario => Set<EstadoUsuario>();
    public DbSet<Foro> Foros => Set<Foro>();
    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Obra> Obras => Set<Obra>();
    public DbSet<ObraActor> ObraActores => Set<ObraActor>();
    public DbSet<ObraColeccion> ObraColecciones => Set<ObraColeccion>();
    public DbSet<ObraDirector> ObraDirectores => Set<ObraDirector>();
    public DbSet<ObraGenero> ObraGeneros => Set<ObraGenero>();
    public DbSet<ObraPlataforma> ObraPlataformas => Set<ObraPlataforma>();
    public DbSet<Plataforma> Plataformas => Set<Plataforma>();
    public DbSet<TipoObra> TiposObra => Set<TipoObra>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Valoracion> Valoraciones => Set<Valoracion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DigitalParalysisDbContext).Assembly);
    }
}
