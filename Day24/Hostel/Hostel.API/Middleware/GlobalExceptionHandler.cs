using Hostel.Core.DTOs;
using Hostel.Core.Exceptions;
using System;

namespace Hostel.API.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly RequestDelegate requestDelegate;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IWebHostEnvironment webHostEnvironment, RequestDelegate requestDelegate)
        {
            this._logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context , Exception ex)
        {
            var correlationId = context.TraceIdentifier;
            context.Response.ContentType = "application/json";

            int statusCode;
            string message;
            string? details;

            switch (ex)
            {
                case NotFoundException nf:
                    statusCode = StatusCodes.Status404NotFound;
                    message = nf.Message;
                    details = webHostEnvironment.IsDevelopment() ? nf.StackTrace : null;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = ex.Message;
                    details = webHostEnvironment.IsDevelopment() ? ex.StackTrace : null;
                    break;
            }

            var error = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                Details = details,
                CorrelationId = correlationId
            };

            //logging the exception

            _logger.LogError(
                ex,
                "Unhandled Exception for {Method} {Path}. CorrelationId:{CorrelationId}",
                context.Request.Method,
                context.Request.Path,
                correlationId);

            context.Response.StatusCode = statusCode;
            var json = System.Text.Json.JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);





        }


    }
}
