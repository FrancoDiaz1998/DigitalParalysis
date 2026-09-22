using DigitalParalysis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class ObraActorConfiguration : IEntityTypeConfiguration<ObraActor>
{
    public void Configure(EntityTypeBuilder<ObraActor> builder)
    {
        builder.ToTable("obra_actor");

        builder.HasKey(relacion => new { relacion.IdObra, relacion.IdActor })
            .HasName("pk_obra_actor");

        builder.Property(relacion => relacion.IdObra)
            .HasColumnName("id_obra")
            .IsRequired();

        builder.Property(relacion => relacion.IdActor)
            .HasColumnName("id_actor")
            .IsRequired();

        builder.HasOne(relacion => relacion.Obra)
            .WithMany(obra => obra.ObraActores)
            .HasForeignKey(relacion => relacion.IdObra)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_actor_obra");

        builder.HasOne(relacion => relacion.Actor)
            .WithMany(actor => actor.ObraActores)
            .HasForeignKey(relacion => relacion.IdActor)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_obra_actor_actor");
    }
}
