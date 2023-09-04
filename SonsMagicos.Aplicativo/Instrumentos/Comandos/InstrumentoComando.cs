using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Comandos;


public abstract class InstrumentoComando : IRequest<Instrumento>
{
    public string Nome { get; set; }
    public TipoInstrumento Tipo { get; set; }
    public decimal Preco { get; set; }
    public string Propriedade { get; set; }
}
