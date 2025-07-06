using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class JwtAuthenticationStateProvider: AuthenticationStateProvider
{
    private readonly ILocalStorageService _storage;

    public JwtAuthenticationStateProvider(ILocalStorageService storage)
    {
        
        _storage = storage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _storage.GetItemAsStringAsync("access_token");

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwtToken.Claims, "Bearer");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    // Call this after login
    public async Task NotifyUserAuthentication(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwtToken.Claims, "Bearer");
        var user = new ClaimsPrincipal(identity);

        var authState = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(authState);
    }

    // Call this after logout
    public void NotifyUserLogout()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

}