using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Rescuit.API.CustomAttribute;

public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    //private readonly IConfiguration _configuration;
    private readonly string _requiredRole;

    public CustomAuthorizeAttribute(string requiredRole)
    {
        _requiredRole = requiredRole;
        //_configuration = configuration;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        //if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer"))
        //{
        //    context.Result = new UnauthorizedResult();
        //    return;
        //}

        //var token = authorizationHeader.Substring("Bearer ".Length);

        try
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            ////var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            //tokenHandler.ValidateToken(token, new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(key),
            //    ValidateIssuer = false,
            //    ValidateAudience = false
            //}, out var validatedToken);

            //var jwtToken = (JwtSecurityToken)validatedToken;
            //var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role");

            //if (roleClaim == null || !_requiredRole.Equals(roleClaim.Value))
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}

            if (!context.HttpContext.User.IsInRole(_requiredRole))
            {
                context.Result = new ForbidResult();
                return;
            }

        }
        catch (Exception)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
