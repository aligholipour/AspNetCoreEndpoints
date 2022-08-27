using AspNetCoreEndpoints.Midllewares;
using AspNetCoreEndpoints.Models;

namespace AspNetCoreEndpoints.Exntensions
{
    public static class EndpointMiddlewareExtensions
    {
        public static IEndpointConventionBuilder UseCustomEndpoint(this IEndpointRouteBuilder endpoints, string pattern = "custom-route")
        {
            var middlewareModel = new MiddlewareModel
            {
                Title = "Custom title",
                ResponseMessage = $"From {pattern} route"
            };

            var pipline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<MyCustomMiddleware>(middlewareModel)
                .Build();

            return endpoints.Map(pattern, pipline);
        }
        public static IEndpointConventionBuilder UseCustomEndpoint(
            this IEndpointRouteBuilder endpoints,
            string pattern,
            Action<MiddlewareModel> message)
        {
            var middlewareModel = new MiddlewareModel();
            message(middlewareModel);

            var pipline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<MyCustomMiddleware>(middlewareModel)
                .Build();

            return endpoints.Map(pattern, pipline);
        }
    }
}
