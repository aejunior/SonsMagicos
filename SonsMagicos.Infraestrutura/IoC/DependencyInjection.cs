using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SonsMagicos.Aplicacao.Interfaces;
using SonsMagicos.Aplicacao.Mappings;
using SonsMagicos.Aplicacao.Servicos;
using SonsMagicos.Dominio.Conta;
using SonsMagicos.Dominio.Interfaces;
using SonsMagicos.Infraestrutura.Contexto;
using SonsMagicos.Infraestrutura.Identidade;
using SonsMagicos.Infraestrutura.Repositorios;

namespace SonsMagicos.Infraestrutura.IoC;

static public class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AplicacaoBdContexto>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b =>
            b.MigrationsAssembly(typeof(AplicacaoBdContexto).Assembly.FullName)));

        services.AddIdentity<AplicacaoUsuario, IdentityRole>().
            AddEntityFrameworkStores<AplicacaoBdContexto>().
            AddDefaultTokenProviders();

        // Argumentação para Apps Web
        services.AddScoped<IInstrumentoRepositorio, InstrumentoRepositorio>();
        services.AddScoped<IInstrumentoServico, InstrumentoServico>();

        services.AddScoped<ISeedUsuarioCargoInicial, SeedUsuarioCargoInicial>();

        // Autenticador
        // services.AddScoped<IAutenticar, AutenticarServico>();

        services.AddAutoMapper(typeof(DominioParaDTOMappingPerfil));

        var manipuladores = AppDomain.CurrentDomain.Load("SonsMagicos.Aplicacao");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(manipuladores));

        return services;
    }
}