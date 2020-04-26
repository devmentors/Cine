using System;
using System.Threading.Tasks;
using Cine.Shared.Exceptions.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Cine.Shared.Exceptions.Middlewares
{
    internal sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionCompositionRoot _exceptionCompositionRoot;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, IExceptionCompositionRoot exceptionCompositionRoot,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _exceptionCompositionRoot = exceptionCompositionRoot;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var responseData = _exceptionCompositionRoot.Map(ex);

                if (responseData is { })
                {
                    _logger.LogError($"An error has occured while processing the request " +
                                     $"{httpContext.Request.Path}. The error code: [{responseData.Code}] " +
                                     $"with message {responseData.Message}");

                    var json = JsonConvert.SerializeObject(new {responseData.Code, responseData.Message });
                    httpContext.Response.StatusCode = (int) responseData.HttpStatus;
                    httpContext.Response.Headers.Add("content-type", "application/json");
                    await httpContext.Response.WriteAsync(json);
                }
                else
                {
                    _logger.LogError($"An unhandled exception will be throw while processing the request " +
                                     $"{httpContext.Request.Path}");
                    throw;
                }
            }
        }
    }
}
