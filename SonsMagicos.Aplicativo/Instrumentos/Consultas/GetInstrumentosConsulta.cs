using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Consultas;

public class GetInstrumentosConsulta : IRequest<IEnumerable<Instrumento>>
{
    public string? Propriedade { get; set; }
    public GetInstrumentosConsulta(string? propriedade)
    {
        Propriedade = propriedade;
    }
}
