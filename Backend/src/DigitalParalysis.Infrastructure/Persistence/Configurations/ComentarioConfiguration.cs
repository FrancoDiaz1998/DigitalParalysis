using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
{
    public void Configure(EntityTypeBuilder<Comentario> builder)
    {
        builder.ToTable(
            "comentario",
            table => table.HasCheckConstraint(
                "ck_comentario_contenido_longitud",
                "char_length(contenido) >= 1"));

        builder.HasKey(comentario => comentario.Id)
            .HasName("pk_comentario");

        builder.Property(comentario => comentario.Id)
            .HasColumnName("id_comentario")
            .ValueGeneratedOnAdd();

        builder.Property(comentario => comentario.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(comentario => comentario.IdForo)
            .HasColumnName("id_foro")
            .IsRequired();

        builder.Property(comentario => comentario.Contenido)
            .HasColumnName("contenido")
            .IsRequired();

        builder.Property(comentario => comentario.FechaComentario)
            .HasColumnName("fecha_comentario")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasOne(comentario => comentario.Usuario)
            .WithMany(usuario => usuario.Comentarios)
            .HasForeignKey(comentario => comentario.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_comentario_usuario");

        builder.HasOne(comentario => comentario.Foro)
            .WithMany(foro => foro.Comentarios)
            .HasForeignKey(comentario => comentario.IdForo)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_comentario_foro");
    }
}
