using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DigitalParalysis.API.ExceptionHandling;
using DigitalParalysis.Application.UseCases.Autenticacion.IniciarSesion;
using DigitalParalysis.Application.UseCases.Usuarios.ObtenerUsuariosPorId;
using DigitalParalysis.Application.UseCases.Usuarios.RegistrarUsuario;
using DigitalParalysis.Infrastructure;
using DigitalParalysis.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
var jwtOptions = JwtOptions.FromConfiguration(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Ingresá únicamente el access token JWT."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IniciarSesionUseCase>();
builder.Services.AddScoped<RegistrarUsuarioUseCase>();
builder.Services.AddScoped<ObtenerUsuarioIdUseCase>();

builder.Services.AddControllers();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;
        options.SaveToken = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ClockSkew = TimeSpan.FromSeconds(30),
            NameClaimType = JwtRegisteredClaimNames.UniqueName,
            RoleClaimType = JwtAccessTokenGenerator.RoleClaimName
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        var (title, defaultDetail) = context.ProblemDetails.Status switch
        {
            StatusCodes.Status400BadRequest => (
                "Solicitud inválida",
                "Uno o más datos de la solicitud no son válidos."),
            StatusCodes.Status401Unauthorized => (
                "No autenticado",
                "Se requiere un token de acceso válido."),
            StatusCodes.Status403Forbidden => (
                "Acceso denegado",
                "No tenés permisos suficientes para realizar esta operación."),
            StatusCodes.Status404NotFound => (
                "Recurso no encontrado",
                "No se encontró el recurso solicitado."),
            StatusCodes.Status405MethodNotAllowed => (
                "Método no permitido",
                "El método HTTP utilizado no está permitido para este recurso."),
            _ => (
                context.ProblemDetails.Title,
                context.ProblemDetails.Detail)
        };

        context.ProblemDetails.Title = title;
        context.ProblemDetails.Detail ??= defaultDetail;
        context.ProblemDetails.Extensions["traceId"] =
            context.HttpContext.TraceIdentifier;
    };
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
