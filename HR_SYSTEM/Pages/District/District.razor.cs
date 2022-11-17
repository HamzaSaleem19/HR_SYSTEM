using HR_SYSTEM.Services;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR_SYSTEM.Pages.District
{
    public partial class District
    {
        [Inject]
        public ProvinceService provinceService { get; set; }
        [Inject]
        public DivisionService divisionService { get; set; }
        [Inject]
        public DistrictService districtService { get; set; }
        public List<ListofDistricts> districtobj = new();
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
            
            await GetListofdistricts();
        }
        public async void GetProvinceCountrywise(int countryId)
        {
            provinceList = new();
            adddistrict.CountryId=countryId;
            provinceList = await divisionService.GetProvincebyid(countryId);
            StateHasChanged();
        }
        public async void GetDivisionProvincewise(int provinceId)
        {
            divisionList = new();
            adddistrict.ProvinceId = provinceId;
            
            divisionList = await districtService.GetDivisionbyid(provinceId);
            StateHasChanged();
        }
        public HR_SYSTEM.ViewModels.DistrictViewModel adddistrict = new();
        protected async void CreateDistrict()
        {
            var response = await districtService.InsertDistrictAsync(adddistrict);
            if (response)
            {
                adddistrict = new();
                Isvisible = false;
                await GetListofdistricts();
                StateHasChanged();

            }


        }

        void Cancel()
        {
            adddistrict = new();
            Isvisible = false;
            StateHasChanged();
        }
        protected async Task GetListofdistricts()
        {
            districtobj = await districtService.GetAllDistrictsAsync();
        }
    }
}
