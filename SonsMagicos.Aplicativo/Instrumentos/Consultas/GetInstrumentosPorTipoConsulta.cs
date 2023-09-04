using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Consultas;

public class GetInstrumentosPorTipoConsulta : IRequest<IEnumerable<Instrumento>>
{
    public TipoInstrumento Tipo { get; set; }

    public GetInstrumentosPorTipoConsulta(TipoInstrumento tipo)
    {
        Tipo = tipo;
    }
}
