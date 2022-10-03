using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using VeterinaryClinicTest.Core.Exceptions;
using Microsoft.Extensions.Hosting;
using NLog;


namespace VeterinaryClinicTest.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

       

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
            

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ClinicExceptions exception)
            { 
                var message = exception.Message;
                _logger.LogError($"Clinic exception with code '{exception.ErrorCode.ToString()}.\n{message}");
                await HandleExceptionAsync(context, exception);
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                _logger.LogError(exception, message);
                await HandleExceptionAsync(context, exception);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var errorCodeName = nameof(HttpStatusCode.InternalServerError);
            var message = string.Empty;
               
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message  = JsonConvert.SerializeObject(validationException.Message);
                    break;
                case ClinicExceptions clinicExceptions:
                    code = clinicExceptions.ErrorCode.StatusCode;
                    errorCodeName = clinicExceptions.ErrorCode.ErrorCodeName;
                    message = string.IsNullOrEmpty(message) ? clinicExceptions.ErrorCode.Message : message;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var responseBody = JsonConvert.SerializeObject(new { errorCodeName,message });
            

            return context.Response.WriteAsync(responseBody);
        }
    }
}

