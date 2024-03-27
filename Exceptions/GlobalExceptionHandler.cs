using System.Net;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace vabalas_api.Exceptions;

public class GlobalExceptionHandler
{
    public static async Task InvokeAsync(HttpContext context)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerFeature?.Error is Exception exception )
        {
            int statusCode;
            string message;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case NotValidException notValidException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = notValidException.Message;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponseDto(statusCode, message);
            var response = new GenericResponse<object>(errorResponse);

            var jsonResponse = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
        }
        {
            
        }
    }
}