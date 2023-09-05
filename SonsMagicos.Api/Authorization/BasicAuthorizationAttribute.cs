using Microsoft.AspNetCore.Authorization;

namespace SonsMagicos.Api.Authorization;

public class BasicAuthorizationAttribute: AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        AuthenticationSchemes = "BasicAuthentication";
    }
}
