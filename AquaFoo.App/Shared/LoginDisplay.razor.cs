using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AquaFoo.App.Shared
{
    public partial class LoginDisplay
    {
        [Inject]
        private NavigationManager _navManager { get; set; }
        
        [Inject]
        private HttpClient _httpClient { get; set; }
        
        void OnClick(string path)
        {
            _navManager.NavigateTo(path, true);
        }

        async Task LogOut()
        {
            await _httpClient.PostAsync($"{_navManager.BaseUri}Identity/Account/LogOut", new StringContent(""));
        }
    }
}