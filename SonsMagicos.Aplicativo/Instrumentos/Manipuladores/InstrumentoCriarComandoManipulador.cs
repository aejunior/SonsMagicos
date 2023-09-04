using MediatR;
using SonsMagicos.Aplicacao.Instrumentos.Comandos;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;

namespace SonsMagicos.Aplicacao.Instrumentos.Manipuladores;

public class InstrumentoCriarManipulador : IRequestHandler<InstrumentoCriarComando, Instrumento>
{
    private readonly IInstrumentoRepositorio _instrumentoRepositorio;

    public InstrumentoCriarManipulador(IInstrumentoRepositorio instrumentoRepositorio)
    {
        _instrumentoRepositorio = instrumentoRepositorio;
    }
    public async Task<Instrumento> Handle(InstrumentoCriarComando request, CancellationToken cancellationToken)
    {
        var instrumento = new Instrumento(request.Nome, request.Tipo, request.Preco, request.Propriedade);

        if (instrumento == null)
        {
            throw new ApplicationException($"Erro ao criar entidade");
        }
        else
        {
            return await _instrumentoRepositorio.CreateAsync(instrumento);
        }
    } 
}
