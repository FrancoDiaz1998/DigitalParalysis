using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraDirectorConfiguration : IEntityTypeConfiguration<ObraDirector>
{
    public void Configure(EntityTypeBuilder<ObraDirector> builder)
    {
        builder.ToTable("obra_director");

        builder.HasKey(relacion => new { relacion.IdObra, relacion.IdDirector })
            .HasName("pk_obra_director");

        builder.Property(relacion => relacion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(relacion => relacion.IdDirector)
            .HasColumnName("id_director")
            .IsRequired();

        builder.HasOne(relacion => relacion.Obra)
            .WithMany(obra => obra.ObraDirectores)
            .HasForeignKey(relacion => relacion.IdObra)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_director_obra");

        builder.HasOne(relacion => relacion.Director)
            .WithMany(director => director.ObraDirectores)
            .HasForeignKey(relacion => relacion.IdDirector)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_director_director");
    }
}
