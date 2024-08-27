using FluentMigrator;

namespace DB.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_APPOINTMENT, "Criacao da tabela de agendamentos")]
public class Version0000002 : Migration
{
    public override void Up()
    {
        Create.Table("Appointments")
            .WithColumn("Id").AsGuid().PrimaryKey().NotNullable().WithDefault(SystemMethods.NewGuid)
            .WithColumn("Date").AsDateTime().NotNullable()
            .WithColumn("ProviderId").AsGuid().NotNullable()
            .WithColumn("UserId").AsGuid().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
            .WithColumn("UpdatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);    
        
        Create.ForeignKey("FK_Appointments_Provider")
            .FromTable("Appointments").ForeignColumn("ProviderId")
            .ToTable("Users").PrimaryColumn("Id");

        Create.ForeignKey("FK_Appointments_User")
            .FromTable("Appointments").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Appointments_Provider").OnTable("Appointments");
        Delete.ForeignKey("FK_Appointments_User").OnTable("Appointments");

        Delete.Table("Appointments");    }
}