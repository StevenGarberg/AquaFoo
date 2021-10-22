using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace AquaFoo.App.Utilities
{
    public static class AuthStateUtility
    {
        public static async Task<Guid> GetUserId(AuthenticationStateProvider authenticationStateProvider)
        {
            var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdString);
        }
    }
}