using PlannerApp.Shared.Models;
using PlannerApp.Shared.Responses;
namespace PlannerApp.Client.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> RegisterUserAsync(RegisterRequest model);

        //TODO : Migrate login to IAuthenticationService
    }
}
