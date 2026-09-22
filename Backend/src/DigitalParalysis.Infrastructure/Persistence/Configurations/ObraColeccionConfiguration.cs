using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraColeccionConfiguration : IEntityTypeConfiguration<ObraColeccion>
{
    public void Configure(EntityTypeBuilder<ObraColeccion> builder)
    {
        builder.ToTable("obra_coleccion");

        builder.HasKey(relacion => new { relacion.IdObra, relacion.IdColeccion })
            .HasName("pk_obra_coleccion");

        builder.Property(relacion => relacion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(relacion => relacion.IdColeccion)
            .HasColumnName("id_coleccion")
            .IsRequired();

        builder.HasOne(relacion => relacion.Obra)
            .WithMany(obra => obra.ObraColecciones)
            .HasForeignKey(relacion => relacion.IdObra)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_coleccion_obra");

        builder.HasOne(relacion => relacion.Coleccion)
            .WithMany(coleccion => coleccion.ObraColecciones)
            .HasForeignKey(relacion => relacion.IdColeccion)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_coleccion_coleccion");
    }
}
