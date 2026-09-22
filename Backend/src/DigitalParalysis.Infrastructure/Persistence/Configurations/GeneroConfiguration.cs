using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable(
            "genero",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_genero_nombre_longitud",
                    "char_length(nombre) >= 2");
                table.HasCheckConstraint(
                    "ck_genero_descripcion_longitud",
                    "descripcion IS NULL OR char_length(descripcion) >= 2");
            });

        builder.HasKey(genero => genero.Id)
            .HasName("pk_genero");

        builder.Property(genero => genero.Id)
            .HasColumnName("id_genero")
            .ValueGeneratedOnAdd();

        builder.Property(genero => genero.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(genero => genero.Descripcion)
            .HasColumnName("descripcion");

        builder.HasIndex(genero => genero.Nombre)
            .IsUnique()
            .HasDatabaseName("ux_genero_nombre");
    }
}
