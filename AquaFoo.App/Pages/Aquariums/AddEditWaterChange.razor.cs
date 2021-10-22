using System;
using System.Threading.Tasks;
using AquaFoo.App.Models;
using AquaFoo.App.Services;
using AquaFoo.App.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;

namespace AquaFoo.App.Pages.Aquariums
{
    public partial class AddEditWaterChange
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IResourceService<Aquarium> AquariumService { get; set; }
        
        [Parameter] public string AquariumId { get; set; }
        [Parameter] public string WaterChangeId { get; set; }

        private string userId;
        private Aquarium aquarium;
        private WaterChange waterChange;
    
        private bool loadFailed = false;
        private Exception exception;
        
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            userId = (await AuthStateUtility.GetUserId(AuthenticationStateProvider)).ToString();
            
            try
            {
                aquarium = await AquariumService.GetAsync(AquariumId);
                if (aquarium == null || aquarium.OwnerId != userId)
                {
                    NavigationManager.NavigateTo("/aquariums");
                    return;
                }
                
                if (WaterChangeId != null)
                {
                    waterChange = aquarium.WaterChanges.FirstOrDefault(wc => wc.Id == WaterChangeId);
                    if (waterChange == null)
                    {
                        NavigationManager.NavigateTo("/aquariums");
                    }
                }
                else
                {
                    waterChange = new WaterChange
                    {
                        Id = Guid.NewGuid().ToString()
                    };
                }
            }
            catch(Exception e)
            {
                loadFailed = true;
                exception = e;
                NavigationManager.NavigateTo("/aquariums");
            }
        }

        private async Task Submit()
        {
            if (WaterChangeId != null)
            {
                aquarium = await AquariumService.PutAsync(userId, AquariumId, aquarium);
            }
            else
            {
                aquarium.WaterChanges.Add(waterChange);
                aquarium = await AquariumService.PutAsync(userId, AquariumId, aquarium);
            }
            // TODO: Navigate to actual aquarium info page once it exists
            NavigationManager.NavigateTo("/aquariums");
        }
        
        private void Cancel()
        {
            NavigationManager.NavigateTo("/aquariums");
        }
    }
}