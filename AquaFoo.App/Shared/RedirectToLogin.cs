using Microsoft.AspNetCore.Components;

namespace AquaFoo.App.Shared
{
    public partial class RedirectToLogin : ComponentBase
    {
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("/Identity/Account/Login");
        }
    }
}