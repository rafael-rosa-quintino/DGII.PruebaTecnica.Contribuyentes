using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace DGII.PruebaTecnica.Contribuyentes.API.Models
{
    public class ApiResponse<T> where T : class
    {

        public ApiResponse() { 
            Successed= true;
            Data = null!;
            Errors = Enumerable.Empty<ApiResponseError>();
        }

        public ApiResponse(T data)
        {
            Successed = true;
            Data = data;
            Errors = Enumerable.Empty<ApiResponseError>();
        }

        public ApiResponse(T data, IEnumerable<ApiResponseError> errors, bool successed) : this(data)
        {
            Errors = errors;
            Successed = successed;
        }

        public ApiResponse(ApiResponseError apiResponseError)
        {
            this.Errors = new List<ApiResponseError>
            { apiResponseError };

            Data = null!;
            Successed = false;
        }


        [JsonPropertyName("data")]
        public T Data { get; private set; }


        [JsonPropertyName("errors")]
        public IEnumerable<ApiResponseError> Errors { get; private set; }
        
        [JsonPropertyName("successed")]
        public bool Successed { get; private set; }

        public ObjectResult OK()
        {
            return new ObjectResult(this)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public ObjectResult NotFound()
        {
            return new ObjectResult(this)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        public ObjectResult BadRequest()
        {
            return new ObjectResult(this)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }

        public ObjectResult InternalServerError()
        {
            return new ObjectResult(this)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

    }
}
