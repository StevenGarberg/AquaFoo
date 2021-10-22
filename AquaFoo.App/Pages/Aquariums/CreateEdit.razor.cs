using System;
using System.Threading.Tasks;
using AquaFoo.App.Models;
using AquaFoo.App.Services;
using AquaFoo.App.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace AquaFoo.App.Pages.Aquariums
{
    public partial class CreateEdit
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IResourceService<Aquarium> AquariumService { get; set; }
        
        [Parameter] public string Id { get; set; }

        private string userId;
        private Aquarium aquarium;
    
        private bool loadFailed = false;
        private Exception exception;
        
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            
            userId = (await AuthStateUtility.GetUserId(AuthenticationStateProvider)).ToString();
            
            try
            {
                if (Id != null)
                {
                    aquarium = await AquariumService.GetAsync(Id);
                    if (aquarium == null || aquarium.OwnerId != userId)
                    {
                        NavigationManager.NavigateTo("/aquariums");
                    }
                }
                else
                {
                    aquarium = new Aquarium
                    {
                        OwnerId = userId
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
    
        private async Task HandleValidSubmit()
        {
            aquarium = await AquariumService.PostAsync(userId, aquarium);
        }
    
        private async Task Submit()
        {
            if (Id != null)
            {
                aquarium = await AquariumService.PutAsync(userId, aquarium.Id, aquarium);
            }
            else
            {
                aquarium = await AquariumService.PostAsync(userId, aquarium);
            }
            NavigationManager.NavigateTo("/aquariums");
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo("/aquariums");
        }
    }
}