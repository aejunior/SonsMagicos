using Microsoft.AspNetCore.Identity;
using SonsMagicos.Dominio.Conta;

namespace SonsMagicos.Infraestrutura.Identidade;

public class SeedUsuarioCargoInicial : ISeedUsuarioCargoInicial
{
    private readonly UserManager<AplicacaoUsuario> _usuarioGestor;
    private readonly RoleManager<IdentityRole> _cargoGestor;
    public SeedUsuarioCargoInicial(UserManager<AplicacaoUsuario>  usuarioGestor, 
        RoleManager<IdentityRole>  cargoGestor)
    {
        _usuarioGestor = usuarioGestor;
        _cargoGestor = cargoGestor;
    }
    public void SeedCargos()
    {
        if (!_cargoGestor.RoleExistsAsync("Usuario").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Usuario";
            role.NormalizedName = "USUARIO";
            IdentityResult roleResult = _cargoGestor.CreateAsync(role).Result;
        }
        if (!_cargoGestor.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _cargoGestor.CreateAsync(role).Result;
        }
    }

    public void SeedUsuarios()
    {

        if (_usuarioGestor.FindByEmailAsync("usuario@localhost").Result == null)
        {
            AplicacaoUsuario user = new AplicacaoUsuario();
            user.UserName = "usuario@localhost";
            user.Email = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _usuarioGestor.CreateAsync(user, "Senha#dific1l").Result;

            if (result.Succeeded)
            {
                _usuarioGestor.AddToRoleAsync(user, "Usuario").Wait();
            }
        }

        if (_usuarioGestor.FindByEmailAsync("admin@localhost").Result == null)
        {
            AplicacaoUsuario user = new AplicacaoUsuario();
            user.UserName = "admin@localhost";
            user.Email = "admin@localhost";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _usuarioGestor.CreateAsync(user, "Senha#dific1l").Result;

            if (result.Succeeded)
            {
                _usuarioGestor.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
