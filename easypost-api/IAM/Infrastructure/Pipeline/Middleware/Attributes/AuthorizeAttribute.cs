using easypost_api.IAM.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace easypost_api.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var alloAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (alloAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            return;
        }

        var user = (User?)context.HttpContext.Items["User"];

        if (user == null) context.Result = new UnauthorizedResult();

    }
}