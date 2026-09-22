using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable(
            "actor",
            table =>
            {
                table.HasCheckConstraint(
                    "ck_actor_nombre_longitud",
                    "char_length(nombre) >= 2");
                table.HasCheckConstraint(
                    "ck_actor_apellido_longitud",
                    "char_length(apellido) >= 2");
            });

        builder.HasKey(actor => actor.Id)
            .HasName("pk_actor");

        builder.Property(actor => actor.Id)
            .HasColumnName("id_actor")
            .ValueGeneratedOnAdd();

        builder.Property(actor => actor.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(actor => actor.Apellido)
            .HasColumnName("apellido")
            .IsRequired();

        builder.Property(actor => actor.Pais)
            .HasColumnName("pais")
            .IsRequired();

        builder.Property(actor => actor.Biografia)
            .HasColumnName("biografia");

        builder.Property(actor => actor.Foto)
            .HasColumnName("foto");

        builder.Property(actor => actor.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .HasColumnType("date")
            .IsRequired();
    }
}
