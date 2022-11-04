using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Base;

namespace Web.Filters;

public class ApiBeforeActionFilter: DadosSessaoBase, IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Encontrar forma de pegar usuario logado id pela session storage
        var token = context.HttpContext.Request.Headers["x-web-auth-token"];
        
        
        if (token.ToString() != "") {
            var handler = new JwtSecurityTokenHandler();
            var validarToken = handler.ReadJwtToken(token);
        }
        
        Console.WriteLine("teste");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}