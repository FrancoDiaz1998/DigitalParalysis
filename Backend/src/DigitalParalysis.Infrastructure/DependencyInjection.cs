using DigitalParalysis.Application.Interfaces;
using DigitalParalysis.Domain.Interfaces;
using DigitalParalysis.Infrastructure.Persistence;
using DigitalParalysis.Infrastructure.Persistence.Repositories;
using DigitalParalysis.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalParalysis.Infrastructure;

public static class DependencyInjection
{
    private const string ConnectionStringName = "DefaultConnection";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            ?? throw new InvalidOperationException($"No se configuró la cadena de conexión '{ConnectionStringName}'.");

        var jwtOptions = JwtOptions.FromConfiguration(configuration);

        services.AddDbContext<DigitalParalysisDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                postgresOptions =>
                {
                    postgresOptions.MigrationsAssembly(
                        typeof(DigitalParalysisDbContext).Assembly.FullName);

                    postgresOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorCodesToAdd: null);
                });
        });

        services.Configure<PasswordHasherOptions>(options =>
        {
            options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
            options.IterationCount = 220_000;
        });

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton(jwtOptions);
        services.AddSingleton<IAccessTokenGenerator, JwtAccessTokenGenerator>();

        return services;
    }
}
