using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraConfiguration : IEntityTypeConfiguration<Obra>
{
    public void Configure(EntityTypeBuilder<Obra> builder)
    {
        builder.ToTable(
            "obra",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_obra_titulo_longitud",
                    "char_length(titulo) >= 1");
                table.HasCheckConstraint(
                    "ck_obra_anio",
                    "anio >= 1888");
                table.HasCheckConstraint(
                    "ck_obra_duracion",
                    "duracion > 0");
            });

        builder.HasKey(obra => obra.Id)
            .HasName("pk_obra");

        builder.Property(obra => obra.Id)
            .HasColumnName("id_obra")
            .ValueGeneratedOnAdd();

        builder.Property(obra => obra.IdTipoObra)
            .HasColumnName("id_tipo")
            .IsRequired();

        builder.Property(obra => obra.Titulo)
            .HasColumnName("titulo")
            .IsRequired();

        builder.Property(obra => obra.Anio)
            .HasColumnName("anio")
            .IsRequired();

        builder.Property(obra => obra.Sinopsis)
            .HasColumnName("sinopsis")
            .IsRequired();

        builder.Property(obra => obra.Duracion)
            .HasColumnName("duracion")
            .IsRequired();

        builder.Property(obra => obra.Foto)
            .HasColumnName("foto");

        builder.Property(obra => obra.DatosCuriosos)
            .HasColumnName("datos_curiosos");

        builder.Property(obra => obra.PaisOrigen)
            .HasColumnName("pais_origen")
            .IsRequired();

        builder.HasOne(obra => obra.TipoObra)
            .WithMany(tipo => tipo.Obras)
            .HasForeignKey(obra => obra.IdTipoObra)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_obra_tipo");
    }
}
