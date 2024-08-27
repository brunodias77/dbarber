using FluentMigrator;

namespace DB.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_USER, "Criacao da tabela de usuarios")]
public class Version0000001 : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("LastName").AsString(100).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable().Unique()
            .WithColumn("Password").AsString(255).NotNullable()
            .WithColumn("Avatar").AsString(255).Nullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}