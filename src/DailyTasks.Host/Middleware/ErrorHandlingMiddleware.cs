using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AgrotoolsMaps.Api.Responses;
using AgrotoolsMaps.Application.Interfaces.LogService;
using AgrotoolsMaps.Application.UseCases.Shared;
using Elastic.Apm;
using Elastic.Apm.Api;
using Newtonsoft.Json;

namespace AgrotoolsMaps.Host.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog<ErrorHandlingMiddleware> _log;

        public ErrorHandlingMiddleware(RequestDelegate next, ILog<ErrorHandlingMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ITransaction transaction = Agent.Tracer.CurrentTransaction;
                transaction?.CaptureErrorLog(new ErrorLog(ex.Message), null, ex); 
                _log.Error(ex, context.Request.Body);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorResponse("Ocorreu um erro na api.");
            var result = JsonConvert.SerializeObject(new ErrorApi(string.Empty, new[] { errorResponse }));
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}