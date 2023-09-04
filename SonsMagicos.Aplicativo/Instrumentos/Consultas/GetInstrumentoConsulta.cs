using MediatR;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Instrumentos.Consultas;

public class GetInstrumentoConsulta : IRequest<Instrumento>
{
    public int Id { get; set; }
    public GetInstrumentoConsulta(int id)
    {
        Id = id;
    }
}
