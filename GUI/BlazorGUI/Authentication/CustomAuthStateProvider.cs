using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorGUI.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
