using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class TipoObraConfiguration : IEntityTypeConfiguration<TipoObra>
{
    public void Configure(EntityTypeBuilder<TipoObra> builder)
    {
        builder.ToTable("tipo_obra");

        builder.HasKey(tipo => tipo.Id)
            .HasName("pk_tipo_obra");

        builder.Property(tipo => tipo.Id)
            .HasColumnName("id_tipo")
            .ValueGeneratedOnAdd();

        builder.Property(tipo => tipo.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(tipo => tipo.Descripcion)
            .HasColumnName("descripcion");

        builder.HasIndex(tipo => tipo.Nombre)
            .IsUnique()
            .HasDatabaseName("ux_tipo_obra_nombre");
    }
}
