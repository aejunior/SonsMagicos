namespace SonsMagicos.Dominio.Conta;

public interface IAutenticar
{
    Task<bool> Autenticar(string email, string senha);
}
