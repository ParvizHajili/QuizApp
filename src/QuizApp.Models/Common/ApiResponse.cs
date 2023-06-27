using System.Net;

namespace QuizApp.Models.Common
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Messages { get; set; }
        public bool IsSuccess { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public static ApiResponse Success(string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse()
            {
                StatusCode = statusCode,
                Messages = message,
                IsSuccess = true
            };
        }
        public static ApiResponse Success<T>(T data, string message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            where T : class
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Messages = message,
                IsSuccess = true,
                Data = data
            };
        }
        public static ApiResponse Fail(string message = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResponse()
            {
                StatusCode = statusCode,
                Messages = message,
                IsSuccess = false
            };
        }
        public static ApiResponse Fail(Dictionary<string,string> errors, string message = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse()
            {
                StatusCode = statusCode,
                Messages = message,
                IsSuccess = false,
                Errors =errors  
            };
        }
    }

    public class ApiResponse<T> : ApiResponse where T : class
    {
        public T Data { get; set; }
    }
}
