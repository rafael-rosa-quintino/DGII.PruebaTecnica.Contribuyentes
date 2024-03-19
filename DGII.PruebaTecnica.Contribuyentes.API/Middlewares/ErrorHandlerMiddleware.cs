using DGII.PruebaTecnica.Contribuyentes.API.Models;
using DGII.PruebaTecnica.Contribuyentes.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace DGII.PruebaTecnica.Contribuyentes.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                ApiResponseError apiResponseError= null!;
                int statusCode = (int)HttpStatusCode.InternalServerError;

                switch (ex)
                {
                    case AppSettingMissingKeyException e:
                        apiResponseError = GetFromException(e);
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case NotFoundException e:
                        apiResponseError = GetFromException(e);
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case Domain.Exceptions.ArgumentException e:
                        apiResponseError = GetFromException(e);
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Domain.Exceptions.DomainException e:
                        apiResponseError = GetFromException(e);
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    default:
                        apiResponseError = GetFromException(ex);
                        break;
                }

                _logger.LogError(new EventId(), ex.GetBaseException().Message);

                response.StatusCode = statusCode;
                ApiResponse<object> apiResponse = new ApiResponse<object>(apiResponseError);
                var result = JsonSerializer.Serialize(apiResponse);
                
                await response.WriteAsync(result);
            }
        }


        private ApiResponseError GetFromException( Exception ex)
        {
            return new ApiResponseError(ex.HResult.ToString(), ex.GetBaseException().Message, ex.Data, ex.ToString());
        }
    }
}
