using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Consultas;

public class GetInstrumentosLikePropriedadeConsulta : IRequest<IEnumerable<Instrumento>>
{
    public string Propriedade { get; set; }

    public GetInstrumentosLikePropriedadeConsulta(string propriedade)
    {
        Propriedade = propriedade;
    }
}
