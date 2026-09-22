using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ForoConfiguration : IEntityTypeConfiguration<Foro>
{
    public void Configure(EntityTypeBuilder<Foro> builder)
    {
        builder.ToTable(
            "foro",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_foro_titulo_longitud",
                    "char_length(titulo) >= 3");
                table.HasCheckConstraint(
                    "ck_foro_contenido_longitud",
                    "char_length(contenido) >= 1");
            });

        builder.HasKey(foro => foro.Id)
            .HasName("pk_foro");

        builder.Property(foro => foro.Id)
            .HasColumnName("id_foro")
            .ValueGeneratedOnAdd();

        builder.Property(foro => foro.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(foro => foro.Titulo)
            .HasColumnName("titulo")
            .IsRequired();

        builder.Property(foro => foro.Contenido)
            .HasColumnName("contenido")
            .IsRequired();

        builder.Property(foro => foro.FechaCreacion)
            .HasColumnName("fecha_creacion")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasOne(foro => foro.Usuario)
            .WithMany(usuario => usuario.Foros)
            .HasForeignKey(foro => foro.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_foro_usuario");
    }
}
