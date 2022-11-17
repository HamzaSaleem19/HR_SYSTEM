using HR_SYSTEM.Services;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_SYSTEM.Pages.Divivsion
{
    public partial class Division
    {
        [Inject]
        public ProvinceService provinceService { get; set; }
        [Inject]
        public DivisionService divisionService { get; set; }
        public List<ListofDivisions> divisionobj = new();
        public List<SelectListItem> CountryList = new();
        public List<SelectListItem> provinceList = new();
        bool Isvisible { get; set; } = false;
        public void ShowForm()
        {
            Isvisible = true;
        }


        protected override async Task OnInitializedAsync()
        {

            CountryList = await provinceService.GetCountries();
            await GetListofdivisions();
        }
        public async void GetProvinceCountrywise(int countryId)
        {
            provinceList = new();
            adddivision.CountryId = countryId;
            provinceList = await divisionService.GetProvincebyid(countryId);
            StateHasChanged();
        }
        public HR_SYSTEM.ViewModels.DivisionViewModel adddivision = new();
        protected async void CreateDivision()
        {
         var response =   await divisionService.InsertDivisionAsync(adddivision);
            if (response)
            {
                adddivision = new();
                Isvisible = false;
                await GetListofdivisions();
                StateHasChanged();

            }
           

        }

        void Cancel()
        {
            adddivision = new();
            Isvisible = false;
            StateHasChanged();
        }
        protected async Task GetListofdivisions()
        {
            divisionobj = await divisionService.GetAllDivisionsAsync();
        }
    }
}
