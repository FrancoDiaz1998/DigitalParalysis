using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalParalysis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "actor",
                schema: "public",
                columns: table => new
                {
                    id_actor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    pais = table.Column<string>(type: "text", nullable: false),
                    biografia = table.Column<string>(type: "text", nullable: true),
                    foto = table.Column<string>(type: "text", nullable: true),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_actor", x => x.id_actor);
                    table.CheckConstraint("ck_actor_apellido_longitud", "char_length(apellido) >= 2");
                    table.CheckConstraint("ck_actor_nombre_longitud", "char_length(nombre) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "director",
                schema: "public",
                columns: table => new
                {
                    id_director = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    pais = table.Column<string>(type: "text", nullable: false),
                    biografia = table.Column<string>(type: "text", nullable: true),
                    foto = table.Column<string>(type: "text", nullable: true),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_director", x => x.id_director);
                    table.CheckConstraint("ck_director_apellido_longitud", "char_length(apellido) >= 2");
                    table.CheckConstraint("ck_director_nombre_longitud", "char_length(nombre) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "estado_usuario",
                schema: "public",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estado_usuario", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "genero",
                schema: "public",
                columns: table => new
                {
                    id_genero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genero", x => x.id_genero);
                    table.CheckConstraint("ck_genero_descripcion_longitud", "descripcion IS NULL OR char_length(descripcion) >= 2");
                    table.CheckConstraint("ck_genero_nombre_longitud", "char_length(nombre) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "plataforma",
                schema: "public",
                columns: table => new
                {
                    id_plataforma = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    pais = table.Column<string>(type: "text", nullable: false),
                    biografia = table.Column<string>(type: "text", nullable: true),
                    foto = table.Column<string>(type: "text", nullable: true),
                    fecha_fundacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plataforma", x => x.id_plataforma);
                    table.CheckConstraint("ck_plataforma_nombre_longitud", "char_length(nombre) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "tipo_obra",
                schema: "public",
                columns: table => new
                {
                    id_tipo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipo_obra", x => x.id_tipo);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "public",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    contrasena_hash = table.Column<string>(type: "text", nullable: false),
                    foto = table.Column<string>(type: "text", nullable: true),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    rol = table.Column<string>(type: "text", nullable: false, defaultValue: "usuario"),
                    id_estado = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    fecha_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    fecha_fin_suspension = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario", x => x.id_usuario);
                    table.CheckConstraint("ck_usuario_apellido_longitud", "char_length(apellido) >= 2");
                    table.CheckConstraint("ck_usuario_nombre_longitud", "char_length(nombre) >= 2");
                    table.CheckConstraint("ck_usuario_nombre_usuario_longitud", "char_length(nombre_usuario) >= 2");
                    table.CheckConstraint("ck_usuario_rol", "rol IN ('usuario', 'admin')");
                    table.ForeignKey(
                        name: "fk_usuario_estado",
                        column: x => x.id_estado,
                        principalSchema: "public",
                        principalTable: "estado_usuario",
                        principalColumn: "id_estado");
                });

            migrationBuilder.CreateTable(
                name: "obra",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_tipo = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    anio = table.Column<int>(type: "integer", nullable: false),
                    sinopsis = table.Column<string>(type: "text", nullable: false),
                    duracion = table.Column<int>(type: "integer", nullable: false),
                    foto = table.Column<string>(type: "text", nullable: true),
                    datos_curiosos = table.Column<string>(type: "text", nullable: true),
                    pais_origen = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra", x => x.id_obra);
                    table.CheckConstraint("ck_obra_anio", "anio >= 1888");
                    table.CheckConstraint("ck_obra_duracion", "duracion > 0");
                    table.CheckConstraint("ck_obra_titulo_longitud", "char_length(titulo) >= 1");
                    table.ForeignKey(
                        name: "fk_obra_tipo",
                        column: x => x.id_tipo,
                        principalSchema: "public",
                        principalTable: "tipo_obra",
                        principalColumn: "id_tipo");
                });

            migrationBuilder.CreateTable(
                name: "articulo",
                schema: "public",
                columns: table => new
                {
                    id_articulo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    contenido = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_articulo", x => x.id_articulo);
                    table.CheckConstraint("ck_articulo_contenido_longitud", "char_length(contenido) >= 1");
                    table.CheckConstraint("ck_articulo_titulo_longitud", "char_length(titulo) >= 3");
                    table.ForeignKey(
                        name: "fk_articulo_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "coleccion",
                schema: "public",
                columns: table => new
                {
                    id_coleccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coleccion", x => x.id_coleccion);
                    table.CheckConstraint("ck_coleccion_nombre_longitud", "char_length(nombre) >= 1");
                    table.ForeignKey(
                        name: "fk_coleccion_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "foro",
                schema: "public",
                columns: table => new
                {
                    id_foro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    contenido = table.Column<string>(type: "text", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_foro", x => x.id_foro);
                    table.CheckConstraint("ck_foro_contenido_longitud", "char_length(contenido) >= 1");
                    table.CheckConstraint("ck_foro_titulo_longitud", "char_length(titulo) >= 3");
                    table.ForeignKey(
                        name: "fk_foro_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "obra_actor",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_actor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra_actor", x => new { x.id_obra, x.id_actor });
                    table.ForeignKey(
                        name: "fk_obra_actor_actor",
                        column: x => x.id_actor,
                        principalSchema: "public",
                        principalTable: "actor",
                        principalColumn: "id_actor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_obra_actor_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obra_director",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_director = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra_director", x => new { x.id_obra, x.id_director });
                    table.ForeignKey(
                        name: "fk_obra_director_director",
                        column: x => x.id_director,
                        principalSchema: "public",
                        principalTable: "director",
                        principalColumn: "id_director",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_obra_director_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obra_genero",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_genero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra_genero", x => new { x.id_obra, x.id_genero });
                    table.ForeignKey(
                        name: "fk_obra_genero_genero",
                        column: x => x.id_genero,
                        principalSchema: "public",
                        principalTable: "genero",
                        principalColumn: "id_genero");
                    table.ForeignKey(
                        name: "fk_obra_genero_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra");
                });

            migrationBuilder.CreateTable(
                name: "obra_plataforma",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_plataforma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra_plataforma", x => new { x.id_obra, x.id_plataforma });
                    table.ForeignKey(
                        name: "fk_obra_plataforma_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra");
                    table.ForeignKey(
                        name: "fk_obra_plataforma_plataforma",
                        column: x => x.id_plataforma,
                        principalSchema: "public",
                        principalTable: "plataforma",
                        principalColumn: "id_plataforma");
                });

            migrationBuilder.CreateTable(
                name: "valoracion",
                schema: "public",
                columns: table => new
                {
                    id_valoracion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    puntuacion = table.Column<int>(type: "integer", nullable: false),
                    resenia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_valoracion", x => x.id_valoracion);
                    table.CheckConstraint("ck_valoracion_puntuacion", "puntuacion BETWEEN 1 AND 10");
                    table.ForeignKey(
                        name: "fk_valoracion_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra");
                    table.ForeignKey(
                        name: "fk_valoracion_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "obra_coleccion",
                schema: "public",
                columns: table => new
                {
                    id_obra = table.Column<int>(type: "integer", nullable: false),
                    id_coleccion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_obra_coleccion", x => new { x.id_obra, x.id_coleccion });
                    table.ForeignKey(
                        name: "fk_obra_coleccion_coleccion",
                        column: x => x.id_coleccion,
                        principalSchema: "public",
                        principalTable: "coleccion",
                        principalColumn: "id_coleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_obra_coleccion_obra",
                        column: x => x.id_obra,
                        principalSchema: "public",
                        principalTable: "obra",
                        principalColumn: "id_obra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comentario",
                schema: "public",
                columns: table => new
                {
                    id_comentario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_foro = table.Column<int>(type: "integer", nullable: false),
                    contenido = table.Column<string>(type: "text", nullable: false),
                    fecha_comentario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comentario", x => x.id_comentario);
                    table.CheckConstraint("ck_comentario_contenido_longitud", "char_length(contenido) >= 1");
                    table.ForeignKey(
                        name: "fk_comentario_foro",
                        column: x => x.id_foro,
                        principalSchema: "public",
                        principalTable: "foro",
                        principalColumn: "id_foro");
                    table.ForeignKey(
                        name: "fk_comentario_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "like_comentario",
                schema: "public",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_comentario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_like_comentario", x => new { x.id_usuario, x.id_comentario });
                    table.ForeignKey(
                        name: "fk_like_comentario_comentario",
                        column: x => x.id_comentario,
                        principalSchema: "public",
                        principalTable: "comentario",
                        principalColumn: "id_comentario");
                    table.ForeignKey(
                        name: "fk_like_comentario_usuario",
                        column: x => x.id_usuario,
                        principalSchema: "public",
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "estado_usuario",
                columns: new[] { "id_estado", "nombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Suspendido" },
                    { 3, "Eliminado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_articulo_id_usuario",
                schema: "public",
                table: "articulo",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "ux_coleccion_usuario_nombre",
                schema: "public",
                table: "coleccion",
                columns: new[] { "id_usuario", "nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comentario_id_foro",
                schema: "public",
                table: "comentario",
                column: "id_foro");

            migrationBuilder.CreateIndex(
                name: "IX_comentario_id_usuario",
                schema: "public",
                table: "comentario",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "ux_estado_usuario_nombre",
                schema: "public",
                table: "estado_usuario",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_foro_id_usuario",
                schema: "public",
                table: "foro",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "ux_genero_nombre",
                schema: "public",
                table: "genero",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_like_comentario_id_comentario",
                schema: "public",
                table: "like_comentario",
                column: "id_comentario");

            migrationBuilder.CreateIndex(
                name: "IX_obra_id_tipo",
                schema: "public",
                table: "obra",
                column: "id_tipo");

            migrationBuilder.CreateIndex(
                name: "IX_obra_actor_id_actor",
                schema: "public",
                table: "obra_actor",
                column: "id_actor");

            migrationBuilder.CreateIndex(
                name: "IX_obra_coleccion_id_coleccion",
                schema: "public",
                table: "obra_coleccion",
                column: "id_coleccion");

            migrationBuilder.CreateIndex(
                name: "IX_obra_director_id_director",
                schema: "public",
                table: "obra_director",
                column: "id_director");

            migrationBuilder.CreateIndex(
                name: "IX_obra_genero_id_genero",
                schema: "public",
                table: "obra_genero",
                column: "id_genero");

            migrationBuilder.CreateIndex(
                name: "IX_obra_plataforma_id_plataforma",
                schema: "public",
                table: "obra_plataforma",
                column: "id_plataforma");

            migrationBuilder.CreateIndex(
                name: "ux_plataforma_nombre",
                schema: "public",
                table: "plataforma",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_tipo_obra_nombre",
                schema: "public",
                table: "tipo_obra",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_estado",
                schema: "public",
                table: "usuario",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "ux_usuario_email",
                schema: "public",
                table: "usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_usuario_nombre_usuario",
                schema: "public",
                table: "usuario",
                column: "nombre_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_valoracion_id_obra",
                schema: "public",
                table: "valoracion",
                column: "id_obra");

            migrationBuilder.CreateIndex(
                name: "ux_valoracion_usuario_obra",
                schema: "public",
                table: "valoracion",
                columns: new[] { "id_usuario", "id_obra" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articulo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "like_comentario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra_actor",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra_coleccion",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra_director",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra_genero",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra_plataforma",
                schema: "public");

            migrationBuilder.DropTable(
                name: "valoracion",
                schema: "public");

            migrationBuilder.DropTable(
                name: "comentario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "actor",
                schema: "public");

            migrationBuilder.DropTable(
                name: "coleccion",
                schema: "public");

            migrationBuilder.DropTable(
                name: "director",
                schema: "public");

            migrationBuilder.DropTable(
                name: "genero",
                schema: "public");

            migrationBuilder.DropTable(
                name: "plataforma",
                schema: "public");

            migrationBuilder.DropTable(
                name: "obra",
                schema: "public");

            migrationBuilder.DropTable(
                name: "foro",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tipo_obra",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "estado_usuario",
                schema: "public");
        }
    }
}
