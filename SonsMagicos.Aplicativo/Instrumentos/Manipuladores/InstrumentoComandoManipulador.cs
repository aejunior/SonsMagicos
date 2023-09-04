using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Consultas;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentoComandoManipulador : IRequestHandler<GetInstrumentoConsulta, Instrumento>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentoComandoManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio;
    }

    public async Task<Instrumento> Handle(GetInstrumentoConsulta request, CancellationToken cancellationToken)
    {
        return await _instrumentoRepositorio.GetInstrumentoAsync(request.Id);
    }
}
