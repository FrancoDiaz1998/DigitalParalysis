using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("like_comentario");

        builder.HasKey(like => new { like.IdUsuario, like.IdComentario })
            .HasName("pk_like_comentario");

        builder.Property(like => like.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(like => like.IdComentario)
            .HasColumnName("id_comentario")
            .IsRequired();

        builder.HasOne(like => like.Usuario)
            .WithMany(usuario => usuario.Likes)
            .HasForeignKey(like => like.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_like_comentario_usuario");

        builder.HasOne(like => like.Comentario)
            .WithMany(comentario => comentario.Likes)
            .HasForeignKey(like => like.IdComentario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_like_comentario_comentario");
    }
}
