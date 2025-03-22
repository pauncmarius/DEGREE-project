
using FCUnirea.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FCUnirea.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode;
            string result;

            switch (ex)
            {
                case NotAvailableException notAvailable:
                    httpStatusCode = HttpStatusCode.Unauthorized; // 401
                    result = JsonSerializer.Serialize(new { error = notAvailable.Message });
                    break;

                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest; // 400
                    result = validationException.Message; // deja e JSON serializat
                    break;

                default:
                    httpStatusCode = HttpStatusCode.InternalServerError; // 500
                    result = JsonSerializer.Serialize(new { error = "A apărut o eroare internă." });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }

    }
}