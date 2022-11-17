using HR_SYSTEM.Services;
using Microsoft.AspNetCore.Components;

namespace HR_SYSTEM.Pages.ANR
{
    public partial class AddANR
    {
        [Inject]
        public AnrService anrService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public HR_SYSTEM.Models.ANR addanr = new();
        protected async void CreateANR()
        {
            await anrService.InsertAnrAsync(addanr);
            NavigationManager.NavigateTo("/ANR/AddANR", true);
        }

        void Cancel()
        {
            addanr = new();
            StateHasChanged();
        }

    }
}
