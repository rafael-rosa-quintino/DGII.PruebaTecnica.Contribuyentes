using System.Text.Json.Serialization;

namespace DGII.PruebaTecnica.Contribuyentes.API.Models
{
    public class ApiResponseError
    {

        [JsonPropertyName("code")]
        public string Code { get; private set; }

        [JsonPropertyName("message")]
        public string Message { get; private set; }

        [JsonPropertyName("data")]
        public object Data { get; private set; }

        [JsonPropertyName("details")]
        public string Details { get; private set; }

        public ApiResponseError(string code, string message, object data, string details)
        {
            Code = code;
            Message = message;
            Data = data;
            Details = details;
        }

        public ApiResponseError(string message)
        {
            Message = message;
            Code = "500";
            Data = null!;
            Details= null!;
        }

        public ApiResponseError(string message, object data, string details = null!) :this(message)
        {
            Data = data;
            Details = details;
        }

        public ApiResponseError(string message, string code, string details = null!) : this(message)
        {
            Code = code;
            Details = details;
        }
    }
}
