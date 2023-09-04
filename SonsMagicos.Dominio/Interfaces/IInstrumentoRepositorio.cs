using SonsMagicos.Dominio.Entidades;

namespace SonsMagicos.Dominio.Interfaces;

public interface IInstrumentoRepositorio
{
    Task<IEnumerable<Instrumento>> GetInstrumentosAsync(string? propriedademagica);
    Task<Instrumento> GetInstrumentoAsync(int? id);
    Task<IEnumerable<Instrumento>> GetByTipoInstrumentoAsync(TipoInstrumento tipo);
    Task<decimal> GetByTipoInstrumentoTotalValorAsync(TipoInstrumento tipo);
    Task<IEnumerable<Instrumento>> GetLikePropriedadeInstrumentoAsync(string propriedademagica);
    Task<Instrumento> CreateAsync(Instrumento instrumento);
    Task<Instrumento> UpdateAsync(Instrumento instrumento);
    Task<Instrumento> RemoveAsync(Instrumento instrumento);
}
