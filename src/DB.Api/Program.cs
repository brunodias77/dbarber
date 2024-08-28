using DB.Api.Filters;
using DB.Api.Token;
using DB.Application.Configurations;
using DB.Domain.Token;
using DB.Infrastructure.Configurations;
using DB.Infrastructure.Extensions;
using DB.Infrastructure.Migrations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Configura a definição de segurança para usar JWT.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Cabeçalho de autorização JWT usando o esquema Bearer.
            Insira 'Bearer' [espaço] e então seu token na entrada de texto abaixo.
            Exemplo: 'Bearer e3eae34ad5r5r...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    // Define a exigência de segurança para operações.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
// Adiciona o filtro de exceções globalmente.
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddScoped<ITokenProvider, HttpContextTokenValue>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateDatabase();

app.Run();

void MigrateDatabase()
{
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    DataBaseMigration.Migrate(builder.Configuration.ConnectionString(), serviceScope.ServiceProvider);
}