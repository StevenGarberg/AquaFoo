using AquaFoo.App.Models;
using AquaFoo.App.Services;
using AquaFoo.App.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AquaFoo.App.Pages.Aquariums
{
    public partial class Index
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private DialogService  DialogService  { get; set; }
        [Inject] private NotificationService NotificationService { get; set; }
        [Inject] private IResourceService<Aquarium> AquariumService { get; set; }

        private string userId;
        private List<Aquarium> aquariums;
        
        private RadzenGrid<Aquarium> grid;

        private bool loadFailed = false;
        private Exception exception;

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            
            userId = (await AuthStateUtility.GetUserId(AuthenticationStateProvider)).ToString();
            
            try
            {
                aquariums = await AquariumService.GetAllAsync(userId);
            }
            catch (Exception e)
            {
                loadFailed = true;
                exception = e;
            }
        }

        private void Create()
        {
            NavigationManager.NavigateTo("/aquariums/add");
        }

        private void Edit(string aquariumId)
        {
            NavigationManager.NavigateTo($"/aquariums/{aquariumId}/edit");
        }

        private async Task Delete(string aquariumId)
        {
            var confirmed = await DialogService.Confirm("Are you sure?", "Delete Aquarium",
                new ConfirmOptions {OkButtonText = "Yes", CancelButtonText = "No"});

            if (confirmed == true)
            {
                await AquariumService.DeleteAsync(userId, aquariumId);

                var aquariumName = aquariums.FirstOrDefault(a => a.Id == aquariumId)?.Name;
                aquariums.RemoveAll(a => a.Id == aquariumId);
                await grid.Reload();
                
                NotificationService.Notify(new NotificationMessage
                {
                    Summary = "Success!", Detail = $"\"{aquariumName}\" was deleted.", Duration = 5000f, Severity = NotificationSeverity.Success
                });
            }
        }
    }
}