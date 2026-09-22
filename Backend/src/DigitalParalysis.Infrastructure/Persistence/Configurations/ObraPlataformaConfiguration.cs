using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraPlataformaConfiguration : IEntityTypeConfiguration<ObraPlataforma>
{
    public void Configure(EntityTypeBuilder<ObraPlataforma> builder)
    {
        builder.ToTable("obra_plataforma");

        builder.HasKey(relacion => new { relacion.IdObra, relacion.IdPlataforma })
            .HasName("pk_obra_plataforma");

        builder.Property(relacion => relacion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(relacion => relacion.IdPlataforma)
            .HasColumnName("id_plataforma")
            .IsRequired();

        builder.HasOne(relacion => relacion.Obra)
            .WithMany(obra => obra.ObraPlataformas)
            .HasForeignKey(relacion => relacion.IdObra)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_obra_plataforma_obra");

        builder.HasOne(relacion => relacion.Plataforma)
            .WithMany(plataforma => plataforma.ObraPlataformas)
            .HasForeignKey(relacion => relacion.IdPlataforma)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_obra_plataforma_plataforma");
    }
}
