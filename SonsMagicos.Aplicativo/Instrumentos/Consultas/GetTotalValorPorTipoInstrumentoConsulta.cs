using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Consultas;

public class GetTotalValorPorTipoInstrumentoConsulta : IRequest<decimal>
{
    public TipoInstrumento Tipo { get; set; }

    public GetTotalValorPorTipoInstrumentoConsulta(TipoInstrumento tipo)
    {
        Tipo = tipo;
    }
}
