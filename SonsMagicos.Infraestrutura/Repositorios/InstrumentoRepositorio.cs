using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SonsMagicos.Dominio.Entidades;
using SonsMagicos.Dominio.Interfaces;
using SonsMagicos.Infraestrutura.Contexto;

namespace SonsMagicos.Infraestrutura.Repositorios;

public class InstrumentoRepositorio : IInstrumentoRepositorio
{
    readonly AplicacaoBdContexto _instrumentoContexto;
    public InstrumentoRepositorio(AplicacaoBdContexto contexto)
    {
        _instrumentoContexto = contexto;
    }

    public async Task<Instrumento> CreateAsync(Instrumento instrumento)
    {
        _instrumentoContexto.Add(instrumento);
        await _instrumentoContexto.SaveChangesAsync();
        return instrumento;
    }

    public async Task<IEnumerable<Instrumento>> GetByTipoInstrumentoAsync(TipoInstrumento tipo)
    {
        return await _instrumentoContexto.Instrumentos.Where(e => e.Tipo == tipo).ToListAsync();
    }

    public async Task<decimal> GetByTipoInstrumentoTotalValorAsync(TipoInstrumento tipo)
    {
        return await _instrumentoContexto.Instrumentos.Where(e => e.Tipo == tipo).Select(c => c.Preco).SumAsync();
    }

    public async Task<Instrumento> GetInstrumentoAsync(int? id)
    {
        return await _instrumentoContexto.Instrumentos.FindAsync(id);
    }

    public async Task<IEnumerable<Instrumento>> GetInstrumentosAsync(string? propriedademagica)
    {
        var consulta = _instrumentoContexto.Instrumentos;
        if (!propriedademagica.IsNullOrEmpty())
        {
            return await consulta.Where(e => EF.Functions.Like(e.Propriedade, $"%{propriedademagica}%")).ToListAsync();
        }

        return await consulta.ToListAsync();
    }

    public async Task<IEnumerable<Instrumento>> GetLikePropriedadeInstrumentoAsync(string? propriedademagica)
    {
        return await _instrumentoContexto.Instrumentos.Where(e => EF.Functions.Like(e.Propriedade, $"%{propriedademagica}%")).ToListAsync();
    }

    public async Task<Instrumento> RemoveAsync(Instrumento instrumento)
    {
        _instrumentoContexto.Remove(instrumento);
        await _instrumentoContexto.SaveChangesAsync();
        return instrumento;
    }

    public async Task<Instrumento> UpdateAsync(Instrumento instrumento)
    {
        _instrumentoContexto.Update(instrumento);
        await _instrumentoContexto.SaveChangesAsync();
        return instrumento;
    }
}
