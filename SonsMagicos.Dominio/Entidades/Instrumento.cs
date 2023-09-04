using SonsMagicos.Dominio.Validacao;

namespace SonsMagicos.Dominio.Entidades;

public enum TipoInstrumento
{
    CORDA = 1,
    SOPRO = 2,
    PERCUSSAO = 3
}
public sealed class Instrumento : Entidade
{
    public string Nome { get; private set; }
    public TipoInstrumento Tipo { get; private set; }
    public decimal Preco { get; private set; }
    public string Propriedade { get; private set; }

    public Instrumento(string nome, TipoInstrumento tipo, decimal preco, string propriedade)
    {
        ValidarDominio(nome, tipo, preco, propriedade);
    }

    public Instrumento(int id, string nome, TipoInstrumento tipo, decimal preco, string propriedade)
    {
        DominioValidacaoExcecao.When(id < 1, "Valor de ID inválido.");
        Id = id;
        ValidarDominio(nome, tipo, preco, propriedade);

    }
    public void Atualizar(string nome, TipoInstrumento tipo, decimal preco, string propriedade)
    {
        ValidarDominio(nome, tipo, preco, propriedade);

    }
    private void ValidarDominio(string nome, TipoInstrumento tipo, decimal preco, string propriedade)
    {
        DominioValidacaoExcecao.When(string.IsNullOrEmpty(nome), "Nome inválido. É preciso informá-lo.");
        DominioValidacaoExcecao.When(nome.Length < 3 || nome.Length > 60, "Nome inválido. O nome informado é curto, o mínimo são 3 caracteres e no máximo 60.");

        DominioValidacaoExcecao.When(!Enum.IsDefined(typeof(TipoInstrumento), tipo), "Tipo de instrumento inválido.");

        DominioValidacaoExcecao.When(preco < 0, "Valor inválido. O preço não pode ser negativo!");

        DominioValidacaoExcecao.When(string.IsNullOrEmpty(propriedade), "Propriedade inválida. Descreva as propriedades.");
        DominioValidacaoExcecao.When(propriedade.Length > 120, "Propriedade inválida. No máximo de 120 caracteres.");

        Nome = nome;
        Tipo = tipo;
        Preco = preco;
        Propriedade = propriedade;
    }
}