using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraGeneroConfiguration : IEntityTypeConfiguration<ObraGenero>
{
    public void Configure(EntityTypeBuilder<ObraGenero> builder)
    {
        builder.ToTable("obra_genero");

        builder.HasKey(relacion => new { relacion.IdObra, relacion.IdGenero })
            .HasName("pk_obra_genero");

        builder.Property(relacion => relacion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(relacion => relacion.IdGenero)
            .HasColumnName("id_genero")
            .IsRequired();

        builder.HasOne(relacion => relacion.Obra)
            .WithMany(obra => obra.ObraGeneros)
            .HasForeignKey(relacion => relacion.IdObra)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_obra_genero_obra");

        builder.HasOne(relacion => relacion.Genero)
            .WithMany(genero => genero.ObraGeneros)
            .HasForeignKey(relacion => relacion.IdGenero)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_obra_genero_genero");
    }
}
