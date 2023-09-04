using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Consultas;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentosComandoManipulador : IRequestHandler<GetInstrumentosConsulta, IEnumerable<Instrumento>>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentosComandoManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio;
    }

    public async Task<IEnumerable<Instrumento>> Handle(GetInstrumentosConsulta request, CancellationToken cancellationToken)
    {
        return await _instrumentoRepositorio.GetInstrumentosAsync(request.Propriedade);
    }
}
