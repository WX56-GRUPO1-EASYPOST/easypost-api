using easypost_api.IAM.Infrastructurre.Pipeline.Middleware.Components;

namespace easypost_api.IAM.Infrastructurre.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}