using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class EstadoUsuarioConfiguration : IEntityTypeConfiguration<EstadoUsuario>
{
    public void Configure(EntityTypeBuilder<EstadoUsuario> builder)
    {
        builder.ToTable("estado_usuario");

        builder.HasKey(estado => estado.Id)
            .HasName("pk_estado_usuario");

        builder.Property(estado => estado.Id)
            .HasColumnName("id_estado")
            .ValueGeneratedOnAdd();

        builder.Property(estado => estado.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.HasIndex(estado => estado.Nombre)
            .IsUnique()
            .HasDatabaseName("ux_estado_usuario_nombre");

        builder.HasData(
            new { Id = 1, Nombre = "Activo" },
            new { Id = 2, Nombre = "Suspendido" },
            new { Id = 3, Nombre = "Eliminado" });
    }
}
