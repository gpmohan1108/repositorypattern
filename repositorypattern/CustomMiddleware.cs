using Microsoft.AspNetCore.Http;
using repositorypattern.Model;

namespace repositorypattern
{
    public class CustomMiddleware : IMiddleware
    {
        //global exception handling using custom middleware
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);

            }
        }
        private static Task HandleException(HttpContext context, Exception ex) 
        {
           int statuscode = StatusCodes.Status404NotFound;
            var errorresponse = new ErrorResponse
            {
                statuscode = statuscode,
                message = ex.Message,
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statuscode;
            
            return context.Response.WriteAsync(errorresponse.ToString());
        }
    }
}
