using DB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DB.Domain.Repositories;
using DB.Domain.Token;
using DB.Infrastructure.Repositories;
using DB.Infrastructure.Services.Token.Generator;
using DB.Infrastructure.Services.Token.Validator;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DB.Domain.Cryptography;


namespace DB.Infrastructure.Configurations;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddFluenteMigrator(services, configuration);
        AddTokens(services, configuration);
        AddRepositories(services);
        AddPasswordEncrypter(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var version = new Version(8, 4, 0);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<ApplicationDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddFluenteMigrator(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options.AddMySql8().WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("DB.Infrastructure")).For.All();
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    private static void AddTokens(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
        services.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        services.AddScoped<IAccessTokenValidator>(option => new JwtTokenValidator(signingKey!));
    }

    private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Services.Cryptography.BCrypt>();
    }
}