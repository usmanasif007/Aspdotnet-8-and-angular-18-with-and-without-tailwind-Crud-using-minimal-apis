using Assesment_ProductManagementSystem_Usman.OutputData;
using Newtonsoft.Json;
using System.Net;

namespace Assesment_ProductManagementSystem_Usman.Middleware
{
    public class ExceptionHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(new OutputDTO<dynamic>()
                {
                    Succeeded = false,
                    HttpStatusCode = Convert.ToInt32(HttpStatusCode.BadRequest),
                    Message = ex.Message,
                    Data = null
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
