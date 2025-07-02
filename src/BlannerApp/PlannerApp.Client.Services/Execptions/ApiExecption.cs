using PlannerApp.Shared.Responses;
using System.Net;

namespace PlannerApp.Client.Services.Execptions
{
    public class ApiExecption:Exception
    {
        public ApiErrorResponse ApiErrorResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ApiExecption(ApiErrorResponse error ,HttpStatusCode statusCode):this(error)
        {
            StatusCode = statusCode; 
        }

        public ApiExecption(ApiErrorResponse error)
        {
            ApiErrorResponse= error;
        }
    }
}
