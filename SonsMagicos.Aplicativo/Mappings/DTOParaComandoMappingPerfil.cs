using AutoMapper;
using SonsMagicos.Aplicacao.DTOs;
using SonsMagicos.Aplicacao.Instrumentos.Comandos;

namespace SonsMagicos.Aplicacao.Mappings;

internal class DTOParaComandoMappingPerfil : Profile
{
    public DTOParaComandoMappingPerfil()
    {
        CreateMap<InstrumentoDTO, InstrumentoCriarComando>();
        CreateMap<InstrumentoDTO, InstrumentoAtualizarComando>();
    }
}
