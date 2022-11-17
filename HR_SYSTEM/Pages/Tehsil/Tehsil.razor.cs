using HR_SYSTEM.Services;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_SYSTEM.Pages.Tehsil
{
    public partial class Tehsil
    {
        [Inject]
        public ProvinceService provinceService { get; set; }
        [Inject]
        public DivisionService divisionService { get; set; }
        [Inject]
        public DistrictService districtService { get; set; }
        [Inject]
        public TehsilService tehsilService { get; set; }
        public List<ListofTehsils> tehsilobj = new();
        public List<SelectListItem> districtList = new();
        public List<SelectListItem> CountryList = new();
        public List<SelectListItem> provinceList = new();
        public List<SelectListItem> divisionList = new();
        bool Isvisible { get; set; } = false;
        public void ShowForm()
        {
            Isvisible = true;
        }


        protected override async Task OnInitializedAsync()
        {

            CountryList = await provinceService.GetCountries();

            await GetListofTehsils();
        }
        public async void GetProvinceCountrywise(int countryId)
        {
            provinceList = new();
           addtehsil.CountryId = countryId;
            provinceList = await divisionService.GetProvincebyid(countryId);
            StateHasChanged();
        }
        public async void GetDivisionProvincewise(int provinceId)
        {
            divisionList = new();
            addtehsil.ProvinceId = provinceId;

            divisionList = await districtService.GetDivisionbyid(provinceId);
            StateHasChanged();
        }
        public async void GetDistrictDivisionwise(int divisionId)
        {
            districtList = new();
            addtehsil.DivisionId = divisionId;

            districtList = await tehsilService.GetDistrictbyid(divisionId);
            StateHasChanged();
        }

        public HR_SYSTEM.ViewModels.TehsilViewModel addtehsil= new();
        protected async void CreateTehsil()
        {
            var response = await tehsilService.InsertTehsilAsync(addtehsil);
            if (response)
            {
                addtehsil = new();
                Isvisible = false;
                await GetListofTehsils();
                StateHasChanged();

            }


        }

        void Cancel()
        {
            addtehsil = new();
            Isvisible = false;
            StateHasChanged();
        }
        protected async Task GetListofTehsils()
        {
            tehsilobj = await tehsilService.GetAllTehsilsAsync();
        }
    }
}
