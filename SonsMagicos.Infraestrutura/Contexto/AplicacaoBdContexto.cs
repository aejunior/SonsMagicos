using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Infraestrutura.Identidade;

namespace SonsMagicos.Infraestrutura.Contexto;

public class AplicacaoBdContexto : IdentityDbContext<AplicacaoUsuario>
{
    public AplicacaoBdContexto(DbContextOptions<AplicacaoBdContexto> options) : base(options) { }

    public DbSet<Instrumento> Instrumentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacaoBdContexto).Assembly);

        // modelBuilder.ApplyConfiguration(new InstrumentoConfiguracao());
    }

}
