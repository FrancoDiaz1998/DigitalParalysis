using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable(
            "director",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_director_nombre_longitud",
                    "char_length(nombre) >= 2");
                table.HasCheckConstraint(
                    "ck_director_apellido_longitud",
                    "char_length(apellido) >= 2");
            });

        builder.HasKey(director => director.Id)
            .HasName("pk_director");

        builder.Property(director => director.Id)
            .HasColumnName("id_director")
            .ValueGeneratedOnAdd();

        builder.Property(director => director.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(director => director.Apellido)
            .HasColumnName("apellido")
            .IsRequired();

        builder.Property(director => director.Pais)
            .HasColumnName("pais")
            .IsRequired();

        builder.Property(director => director.Biografia)
            .HasColumnName("biografia");

        builder.Property(director => director.Foto)
            .HasColumnName("foto");

        builder.Property(director => director.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .HasColumnType("date")
            .IsRequired();
    }
}
