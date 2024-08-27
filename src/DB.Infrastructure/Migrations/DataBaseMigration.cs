using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Infrastructure.Migrations;

public class DataBaseMigration
{
    public static void Migrate(string connectionString, IServiceProvider serviceProvider)
    {
        MigrationDatabase(serviceProvider);
    }

    private static void MigrationDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
    }
}