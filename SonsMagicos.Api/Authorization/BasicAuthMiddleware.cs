namespace SonsMagicos.Api.Auth;

using System.Net.Http.Headers;
using System.Text;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var username = credentials[0];
            var password = credentials[1];
            // TODO: Implementar busca para autenticar usuário
            context.Items["User"] = true; // await new AutenticarServico() .Autenticar(username, password);
        }
        catch
        {
            // Fazer alguma coisa
        }

        await _next(context);
    }
}