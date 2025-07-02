using PlannerApp.Client.Services.Execptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
using System.Net.Http.Json;

namespace PlannerApp.Client.Services
{
    public class HttpAuthenticationService : IAuthenticationService
    {
        private HttpClient _client;


        public HttpAuthenticationService(HttpClient client)
        {
             _client = client;
        }
        public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
        {
            var response = await _client.PostAsJsonAsync("/api/auth/register", model);
            if(response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;

            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiExecption(errorResponse,response.StatusCode);
            }
        }
    }
}
