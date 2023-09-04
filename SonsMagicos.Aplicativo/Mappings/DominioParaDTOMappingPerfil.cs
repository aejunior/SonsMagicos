using AutoMapper;
using SonsMagicos.Aplicacao.DTOs;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Mappings;

public class DominioParaDTOMappingPerfil : Profile
{
    public DominioParaDTOMappingPerfil()
    {
        CreateMap<Instrumento, InstrumentoDTO>().ReverseMap();
    }
}
