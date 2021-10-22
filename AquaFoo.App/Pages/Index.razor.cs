using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AquaFoo.App.Pages
{
    public partial class Index
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            
            NavigationManager.NavigateTo("/aquariums");
        }
    }
}