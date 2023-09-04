using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Infraestrutura.EntidadesConfiguracao;

public class InstrumentoConfiguracao : IEntityTypeConfiguration<Instrumento>
{
    public void Configure(EntityTypeBuilder<Instrumento> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Nome).HasMaxLength(60).IsRequired();
        builder.Property(p => p.Propriedade).HasMaxLength(120).IsRequired();

        builder.Property(p => p.Preco).HasPrecision(10, 2);
        builder.Property(p => p.Tipo)
            .HasColumnType("int")
            .IsRequired();
    }
}
