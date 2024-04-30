using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;
using System.Security.Claims;

namespace RSAllies.Authentication
{
    public class CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        : AuthenticationStateProvider
    {

        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = httpContextAccessor!.HttpContext!.Session.GetString("UserSession");

                if (string.IsNullOrEmpty(userSession))
                { return await Task.FromResult(new AuthenticationState(_anonymous)); }

                var user = JsonConvert.DeserializeObject<UserDto>(userSession);
                var claimsPrincipal = new ClaimsPrincipal(
                    new ClaimsIdentity(new[]
                        {
                new Claim(ClaimTypes.NameIdentifier, user!.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                        }, "client-authentication")
                    );

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public Task UpdateAuthenticationState(UserDto user)
        {
            httpContextAccessor!.HttpContext!.Session.SetString("UserSession", JsonConvert.SerializeObject(user));
            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.MobilePhone, user.Phone),
                }, "client-authentication")
            );
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            return Task.CompletedTask;
        }

    }
}
