using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Models;
using SonsMagicos.Dominio.Conta;
using SonsMagicos.Infraestrutura.Contexto;
using SonsMagicos.Infraestrutura.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SonsMagicos.Api",
        Description = "Teste Backend JCM",
        Contact = new OpenApiContact
        {
            Name = "Augusto Junior",
            Email = "hello@aejunior.xyz",
            Url = new Uri("https://aejunior.xyz/"),
        },

    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

ExecutingMigration(app);
SeedUserRoles(app);

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {

        var seed = serviceScope.ServiceProvider
                               .GetService<ISeedUsuarioCargoInicial>();
        seed.SeedCargos();
        seed.SeedUsuarios();
    }
}

void ExecutingMigration(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        try
        {
            var dbContext = services.GetRequiredService<AplicacaoBdContexto>();

            if (dbContext.Database.IsSqlServer())
            {
                if (!dbContext.Database.EnsureCreated())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
        catch
        {
        }

    }
}