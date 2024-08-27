using DB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DB.Domain.Repositories;
using DB.Infrastructure.Repositories;
using FluentMigrator.Runner;

namespace DB.Infrastructure.Configurations;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        AddDbContext(services, configuration);
        AddFluenteMigrator(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfigurationManager configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var version = new Version(8, 4, 0);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<ApplicationDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddFluenteMigrator(IServiceCollection services, IConfigurationManager configuration)
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
    }
}