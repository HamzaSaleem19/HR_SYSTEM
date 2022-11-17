using HR_SYSTEM.Services;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_SYSTEM.Pages.Province
{
    public partial class Province
    {
        [Inject]
        public ProvinceService provinceService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        bool Isvisible { get; set; } = false;
        public void ShowForm()
        {
            Isvisible = true;
        }

        public List<ListofProvince> provinceobj = new();
        public List<SelectListItem> CountryList = new();
        protected override async Task OnInitializedAsync()
        {
            
          await GetListofprovinces();
            CountryList = await provinceService.GetCountries();
        }
        public HR_SYSTEM.ViewModels.ProvinceVeiwModel addprovince = new();
        protected async void CreateProvince()
        {
           var response = await provinceService.InsertProvinceAsync(addprovince);
            if (response)
            {
                addprovince = new();
                Isvisible = false;
                await GetListofprovinces();
                StateHasChanged();
            }
            
        }

        void Cancel()
        {
            addprovince = new();
            Isvisible=false;
            StateHasChanged();
        }
        protected async  Task  GetListofprovinces()
        {
            provinceobj = await provinceService.GetAllProvincesAsync();
        }

    }
}

