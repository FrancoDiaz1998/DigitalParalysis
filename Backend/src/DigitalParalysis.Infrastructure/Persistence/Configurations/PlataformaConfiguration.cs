using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class PlataformaConfiguration : IEntityTypeConfiguration<Plataforma>
{
    public void Configure(EntityTypeBuilder<Plataforma> builder)
    {
        builder.ToTable(
            "plataforma",
            table => table.HasCheckConstraint(
                "ck_plataforma_nombre_longitud",
                "char_length(nombre) >= 2"));

        builder.HasKey(plataforma => plataforma.Id)
            .HasName("pk_plataforma");

        builder.Property(plataforma => plataforma.Id)
            .HasColumnName("id_plataforma")
            .ValueGeneratedOnAdd();

        builder.Property(plataforma => plataforma.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(plataforma => plataforma.Pais)
            .HasColumnName("pais")
            .IsRequired();

        builder.Property(plataforma => plataforma.Biografia)
            .HasColumnName("biografia");

        builder.Property(plataforma => plataforma.Foto)
            .HasColumnName("foto");

        builder.Property(plataforma => plataforma.FechaFundacion)
            .HasColumnName("fecha_fundacion")
            .HasColumnType("date");

        builder.HasIndex(plataforma => plataforma.Nombre)
            .IsUnique()
            .HasDatabaseName("ux_plataforma_nombre");
    }
}
