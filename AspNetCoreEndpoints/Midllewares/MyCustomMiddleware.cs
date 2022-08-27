using AspNetCoreEndpoints.Models;

namespace AspNetCoreEndpoints.Midllewares
{
    public class MyCustomMiddleware
    {
        public readonly RequestDelegate _next;
        private readonly MiddlewareModel _middlewareModel;
        public MyCustomMiddleware(RequestDelegate next, MiddlewareModel middlewareModel)
        {
            _next = next;
            _middlewareModel = middlewareModel;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"title: {_middlewareModel.Title} - message: {_middlewareModel.ResponseMessage}");
        }
    }
}
