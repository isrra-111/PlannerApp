using Microsoft.AspNetCore.Components;
using PlannerApp.Client.Services.Execptions;
using PlannerApp.Client.Services.Interfaces;
using PlannerApp.Shared.Models;

namespace BlannerApp.Components.Authentication
{
    public partial class RegisterForm:ComponentBase 
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private RegisterRequest _model = new RegisterRequest();

        private bool _isBusy = false;
        private string _errorMessage = string.Empty;

        private async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;

            try
            {
                await AuthenticationService.RegisterUserAsync(_model);
                Navigation.NavigateTo("/authentication/login");
            }
            catch (ApiExecption ex)
            {
                //Handler errors of the API
                //TODO: Log those errors
                _errorMessage = ex.ApiErrorResponse.Message;
            }
            catch (Exception ex)
            {
                //Handler Error
                _errorMessage = ex.Message;
            }

            _isBusy = false;
        }

        private void RedirectToLogin()
        {
            Navigation.NavigateTo("/authentication/login");
        }
    }
}
