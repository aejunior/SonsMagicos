using SonsMagicos.Aplicacao.DTOs;

namespace SonsMagicos.Aplicacao.Interfaces;

public interface IInstrumentoServico
{
    Task<IEnumerable<InstrumentoDTO>> GetInstrumentosAsync(string? propriedade);
    Task<InstrumentoDTO> GetInstrumentoAsync(int id);
    Task<IEnumerable<InstrumentoDTO>> GetByTipoInstrumentoAsync(TipoInstrumentoDTO tipo);
    Task<decimal> GetTotalValorPorTipoInstrumentoAsync(TipoInstrumentoDTO tipo);
    Task<IEnumerable<InstrumentoDTO>> GetLikePropriedadeInstrumentoAsync(string propriedademagica);
    Task AddAsync(InstrumentoDTO instrumento);
    Task UpdateAsync(InstrumentoDTO instrumento);
    Task RemoveAsync(int? id);
}
