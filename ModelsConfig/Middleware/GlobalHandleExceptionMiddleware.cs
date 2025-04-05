namespace MyProject.API.Config.Middleware
{
    using Microsoft.AspNetCore.Http;
    using MyProject.API.Models;
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class GlobalHandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalHandleExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new APIResponse
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorMessages = new List<string>() { exception.Message },
                IsSuccess = false
            };

            string jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(jsonResponse);
        }
    }

}
