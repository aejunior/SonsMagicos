using Microsoft.AspNetCore.Identity;

using SonsMagicos.Dominio.Conta;

namespace SonsMagicos.Infraestrutura.Identidade;

public class AutenticarServico : IAutenticar
{
    private readonly SignInManager<AplicacaoUsuario> _registroGestor;
    public AutenticarServico(SignInManager<AplicacaoUsuario> registroGestor)
    {
        _registroGestor = registroGestor;
    }

    public async Task<bool> Autenticar(string email, string senha)
    {
        var resultado = await _registroGestor.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);
        return resultado.Succeeded;
    }
}
