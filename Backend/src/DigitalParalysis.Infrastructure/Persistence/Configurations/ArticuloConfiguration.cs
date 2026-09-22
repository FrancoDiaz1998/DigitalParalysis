using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ArticuloConfiguration : IEntityTypeConfiguration<Articulo>
{
    public void Configure(EntityTypeBuilder<Articulo> builder)
    {
        builder.ToTable(
            "articulo",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_articulo_titulo_longitud",
                    "char_length(titulo) >= 3");
                table.HasCheckConstraint(
                    "ck_articulo_contenido_longitud",
                    "char_length(contenido) >= 1");
            });

        builder.HasKey(articulo => articulo.Id)
            .HasName("pk_articulo");

        builder.Property(articulo => articulo.Id)
            .HasColumnName("id_articulo")
            .ValueGeneratedOnAdd();

        builder.Property(articulo => articulo.IdUsuario)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(articulo => articulo.Titulo)
            .HasColumnName("titulo")
            .IsRequired();

        builder.Property(articulo => articulo.Contenido)
            .HasColumnName("contenido")
            .IsRequired();

        builder.Property(articulo => articulo.Fecha)
            .HasColumnName("fecha")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.HasOne(articulo => articulo.Usuario)
            .WithMany(usuario => usuario.Articulos)
            .HasForeignKey(articulo => articulo.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_articulo_usuario");
    }
}
