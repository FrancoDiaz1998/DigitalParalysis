using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ColeccionConfiguration : IEntityTypeConfiguration<Coleccion>
{
    public void Configure(EntityTypeBuilder<Coleccion> builder)
    {
        builder.ToTable(
            "coleccion",
            table => table.HasCheckConstraint(
                "ck_coleccion_nombre_longitud",
                "char_length(nombre) >= 1"));

        builder.HasKey(coleccion => coleccion.Id)
            .HasName("pk_coleccion");

        builder.Property(coleccion => coleccion.Id)
            .HasColumnName("id_coleccion")
            .ValueGeneratedOnAdd();

        builder.Property(coleccion => coleccion.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(coleccion => coleccion.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.HasIndex(coleccion => new { coleccion.IdUsuario, coleccion.Nombre })
            .IsUnique()
            .HasDatabaseName("ux_coleccion_usuario_nombre");

        builder.HasOne(coleccion => coleccion.Usuario)
            .WithMany(usuario => usuario.Colecciones)
            .HasForeignKey(coleccion => coleccion.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_coleccion_usuario");
    }
}
