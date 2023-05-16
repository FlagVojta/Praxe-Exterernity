using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace BlazorApp1.Authentication
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        
        private readonly ProtectedSessionStorage _sessionstorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthentication(ProtectedSessionStorage storage)
        {
            this._sessionstorage = storage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {
                var userSessionStorageResult = await _sessionstorage.GetAsync<UserSession>("UserSession");

                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Login),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {

                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
           
            
        }
        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            
            ClaimsPrincipal claimsprincipal = new();
            if (userSession != null)
            {
                await _sessionstorage.SetAsync("UserSession", userSession);
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Login),
                    new Claim(ClaimTypes.Role, userSession.Role),
                    
                }));
            }
            else
            {
                await _sessionstorage.DeleteAsync("UserSession");
                claimsprincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsprincipal)));
        }


    }
}
