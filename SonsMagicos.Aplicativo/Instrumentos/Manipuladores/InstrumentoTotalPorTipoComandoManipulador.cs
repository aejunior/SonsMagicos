using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Consultas;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentoTotalPorTipoComandoManipulador : IRequestHandler<GetTotalValorPorTipoInstrumentoConsulta, decimal>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentoTotalPorTipoComandoManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio;
    }

    public async Task<decimal> Handle(GetTotalValorPorTipoInstrumentoConsulta request, CancellationToken cancellationToken)
    {
        return await _instrumentoRepositorio.GetByTipoInstrumentoTotalValorAsync(request.Tipo);
    }
}
