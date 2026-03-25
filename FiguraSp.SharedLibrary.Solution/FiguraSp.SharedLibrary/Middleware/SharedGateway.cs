using Microsoft.AspNetCore.Http;

namespace FiguraSp.SharedLibrary.Middleware
{
    public class SharedGateway(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            //Extract specific header from the REQUEST
            //Any ApiGateway request will have 'Figura-Gateway' header attached
            //header is added by the middleware of api-gateway
            var signedHeader = context.Request.Headers["Figura-Gateway"];

            //Null means the request is not coming from api gateway
            if (signedHeader.FirstOrDefault() is null)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Service is unavailable - api gateway stopped it");
                return;
            }
            else
            {
                //execute the next middleware
                await next(context);
            }
        }
    }
}
