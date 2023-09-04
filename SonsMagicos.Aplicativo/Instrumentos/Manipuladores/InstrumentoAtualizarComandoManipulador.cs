using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Comandos;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentoAtualizarComandoManipulador : IRequestHandler<InstrumentoAtualizarComando, Instrumento>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentoAtualizarComandoManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio ??
            throw new ArgumentNullException(nameof(instrumentoRepositorio));
    }

    public async Task<Instrumento> Handle(InstrumentoAtualizarComando request, CancellationToken cancellationToken)
    {
        var instrumento = await _instrumentoRepositorio.GetInstrumentoAsync(request.Id);

        if (instrumento == null)
        {
            throw new ApplicationException($"Entidade não pode ser encontrada");
        }
        else
        {
            instrumento.Atualizar(request.Nome, request.Tipo, request.Preco, request.Propriedade);
            return await _instrumentoRepositorio.UpdateAsync(instrumento);
        }
    }
}
