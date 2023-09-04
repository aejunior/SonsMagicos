using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Comandos;

public class InstrumentoRemoverComando : IRequest<Instrumento>
{
    public int Id { get; set; }

    public InstrumentoRemoverComando(int id)
    {
        Id = id;
    }
}
