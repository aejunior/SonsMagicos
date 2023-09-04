using AutoMapper;
using MediatR;
using SonsMagicos.Aplicacao.DTOs;
using SonsMagicos.Aplicacao.Instrumentos.Comandos;
using SonsMagicos.Aplicacao.Instrumentos.Consultas;
using SonsMagicos.Aplicacao.Interfaces;
using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Aplicacao.Servicos;

public class InstrumentoServico : IInstrumentoServico
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public InstrumentoServico(IMapper mapper, IMediator mediator)
    {

        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<InstrumentoDTO>> GetInstrumentosAsync(string? propriedademagica)
    {
        var instrumentosConsulta = new GetInstrumentosConsulta(propriedademagica);

        if (instrumentosConsulta == null) throw new Exception($"Entidades não foram carregadas");
        var resultado = await _mediator.Send(instrumentosConsulta);
        return _mapper.Map<IEnumerable<InstrumentoDTO>>(resultado);
    }

    public async Task<InstrumentoDTO> GetInstrumentoAsync(int id)
    {
        var instrumentoConsulta = new GetInstrumentoConsulta(id);

        if (instrumentoConsulta == null) throw new Exception($"Entidade não pode ser carregada");
        var resultado = await _mediator.Send(instrumentoConsulta);
        return _mapper.Map<InstrumentoDTO>(resultado);
    }


    public async Task AddAsync(InstrumentoDTO instrumento)
    {
        var instrumentoCriarComando = _mapper.Map<InstrumentoCriarComando>(instrumento);
        await _mediator.Send(instrumentoCriarComando);

    }
    public async Task UpdateAsync(InstrumentoDTO instrumento)
    {
        var instrumentoAtualizarComando = _mapper.Map<InstrumentoAtualizarComando>(instrumento);
        await _mediator.Send(instrumentoAtualizarComando);
    }
    public async Task RemoveAsync(int? id)
    {
        var instrumentoRemoverComando = _mapper.Map<InstrumentoRemoverComando>(id);
        await _mediator.Send(instrumentoRemoverComando);
    }

    public async Task<IEnumerable<InstrumentoDTO>> GetByTipoInstrumentoAsync(TipoInstrumentoDTO tipo)
    {
        var tipoInstrumento = _mapper.Map<TipoInstrumento>(tipo);
        var instrumentoConsulta = new GetInstrumentosPorTipoConsulta(tipoInstrumento);
        if (instrumentoConsulta == null) throw new Exception($"Entidades não foram carregadas");
        var resultado = await _mediator.Send(instrumentoConsulta);
        return _mapper.Map<IEnumerable<InstrumentoDTO>>(resultado);
    }

    public async Task<decimal> GetTotalValorPorTipoInstrumentoAsync(TipoInstrumentoDTO tipo)
    {
        var tipoInstrumento = _mapper.Map<TipoInstrumento>(tipo);
        var instrumentoConsulta = new GetTotalValorPorTipoInstrumentoConsulta(tipoInstrumento);
        if (instrumentoConsulta == null) throw new Exception($"Entidades não foram carregadas");
        var resultado = await _mediator.Send(instrumentoConsulta);
        return resultado;
    }

    public async Task<IEnumerable<InstrumentoDTO>> GetLikePropriedadeInstrumentoAsync(string propriedademagica)
    {
        var instrumentoConsulta = new GetInstrumentosLikePropriedadeConsulta(propriedademagica);
        if (instrumentoConsulta == null) throw new Exception($"Entidades não foram carregadas");
        var resultado = await _mediator.Send(instrumentoConsulta);
        return _mapper.Map<IEnumerable<InstrumentoDTO>>(resultado);
    }

}
