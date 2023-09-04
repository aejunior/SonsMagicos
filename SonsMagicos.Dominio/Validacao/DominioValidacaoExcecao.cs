namespace SonsMagicos.Dominio.Validacao;

public class DominioValidacaoExcecao : Exception
{
    public DominioValidacaoExcecao(string error) : base(error)
    { }

    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DominioValidacaoExcecao(error);
        }
    }
}
