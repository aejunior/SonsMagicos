using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Comandos;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentoRemoverComandoManipulador : IRequestHandler<InstrumentoRemoverComando, Instrumento>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentoRemoverComandoManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio ?? throw new ArgumentNullException(nameof(instrumentoRepositorio));
    }
    public async Task<Instrumento> Handle(InstrumentoRemoverComando request, CancellationToken cancellationToken)
    {
        var instrumento = await _instrumentoRepositorio.GetInstrumentoAsync(request.Id);

        if (instrumento == null)
        {
            throw new ApplicationException($"Entidade não pode ser encontrada");
        }
        else
        {
            return await _instrumentoRepositorio.RemoveAsync(instrumento);
        }
    }
}
