using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ValoracionConfiguration : IEntityTypeConfiguration<Valoracion>
{
    public void Configure(EntityTypeBuilder<Valoracion> builder)
    {
        builder.ToTable(
            "valoracion",
            table => table.HasCheckConstraint(
                "ck_valoracion_puntuacion",
                "puntuacion BETWEEN 1 AND 10"));

        builder.HasKey(valoracion => valoracion.Id)
            .HasName("pk_valoracion");

        builder.Property(valoracion => valoracion.Id)
            .HasColumnName("id_valoracion")
            .ValueGeneratedOnAdd();

        builder.Property(valoracion => valoracion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(valoracion => valoracion.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(valoracion => valoracion.Puntuacion)
            .HasColumnName("puntuacion")
            .IsRequired();

        builder.Property(valoracion => valoracion.Resenia)
            .HasColumnName("resenia");

        builder.HasIndex(valoracion => new { valoracion.IdUsuario, valoracion.IdObra })
            .IsUnique()
            .HasDatabaseName("ux_valoracion_usuario_obra");

        builder.HasOne(valoracion => valoracion.Obra)
            .WithMany(obra => obra.Valoraciones)
            .HasForeignKey(valoracion => valoracion.IdObra)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_valoracion_obra");

        builder.HasOne(valoracion => valoracion.Usuario)
            .WithMany(usuario => usuario.Valoraciones)
            .HasForeignKey(valoracion => valoracion.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_valoracion_usuario");
    }
}
