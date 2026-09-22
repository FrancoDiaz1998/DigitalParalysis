using DigitalParalysis.Domain.Entities;
using DigitalParalysis.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalParalysis.Infrastructure.Persistence.Configurations;

public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario", table =>
        {
            table.HasCheckConstraint(
                "ck_usuario_nombre_longitud",
                "char_length(nombre) >= 2");
            table.HasCheckConstraint(
                "ck_usuario_apellido_longitud",
                "char_length(apellido) >= 2");
            table.HasCheckConstraint(
                "ck_usuario_nombre_usuario_longitud",
                "char_length(nombre_usuario) >= 2");
            table.HasCheckConstraint(
                "ck_usuario_rol",
                "rol IN ('usuario', 'admin')");
        });

        builder.HasKey(usuario => usuario.Id)
            .HasName("pk_usuario");

        builder.Property(usuario => usuario.Id)
            .HasColumnName("id_usuario")
            .ValueGeneratedOnAdd();

        builder.Property(usuario => usuario.Nombre)
            .HasColumnName("nombre")
            .IsRequired();

        builder.Property(usuario => usuario.Apellido)
            .HasColumnName("apellido")
            .IsRequired();

        builder.Property(usuario => usuario.NombreUsuario)
            .HasColumnName("nombre_usuario")
            .IsRequired();

        builder.Property(usuario => usuario.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(usuario => usuario.ContrasenaHash)
            .HasColumnName("contrasena_hash")
            .IsRequired();

        builder.Property(usuario => usuario.Foto)
            .HasColumnName("foto");

        builder.Property(usuario => usuario.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(usuario => usuario.Rol)
            .HasColumnName("rol")
            .HasConversion(
                rol => rol == RolUsuario.Admin ? "admin" : "usuario",
                valor => valor == "admin" ? RolUsuario.Admin : RolUsuario.Usuario)
            .HasDefaultValue(RolUsuario.Usuario)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(usuario => usuario.IdEstado)
            .HasColumnName("id_estado")
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(usuario => usuario.FechaRegistro)
            .HasColumnName("fecha_registro")
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(usuario => usuario.FechaFinSuspension)
            .HasColumnName("fecha_fin_suspension")
            .HasColumnType("timestamp with time zone");

        builder.Property(usuario => usuario.FechaEliminacion)
            .HasColumnName("fecha_eliminacion")
            .HasColumnType("timestamp with time zone");

        builder.Ignore(usuario => usuario.Estado);

        builder.HasIndex(usuario => usuario.NombreUsuario)
            .IsUnique()
            .HasDatabaseName("ux_usuario_nombre_usuario");

        builder.HasIndex(usuario => usuario.Email)
            .IsUnique()
            .HasDatabaseName("ux_usuario_email");

        builder.HasOne(usuario => usuario.EstadoUsuario)
            .WithMany(estado => estado.Usuarios)
            .HasForeignKey(usuario => usuario.IdEstado)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("fk_usuario_estado");
    }
}
