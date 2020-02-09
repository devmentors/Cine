using System;
using System.Threading.Tasks;
using Cine.Shared.Exceptions.Mappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Cine.Shared.Exceptions.Middlewares
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

        public ExceptionMiddleware(RequestDelegate next, IExceptionCompositionRoot exceptionCompositionRoot)
        {
            _next = next;
            _exceptionCompositionRoot = exceptionCompositionRoot;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = _exceptionCompositionRoot.Map(ex);

                if (response is {httpStatusCode: var httpStatusCode, errorCode: var errorCode })
                {
                    var json = JsonConvert.SerializeObject(new { error =errorCode });
                    await context.Response.WriteAsync(json);
                    context.Response.StatusCode = httpStatusCode;
                    context.Response.Headers.Add("content-type", "application/json");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
