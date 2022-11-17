using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_SYSTEM.Services;

namespace HR_SYSTEM.Pages
{
    public partial class Companies
    {
        public List<SelectListItem> DepartmentList = new();
        [Inject]
        public EmployeeService empployeeService { get; set; }

        public List<HR_SYSTEM.Models.Company> Compob = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Compob = await companyService.GetAllCompaniesAsync
                ();
        }
        public HR_SYSTEM.Models.Company addcompanydata = new();
        protected async void CreateCompany()
        {
            await companyService.InsertCompanyAsync(addcompanydata);
            NavigationManager.NavigateTo("Companies", true);
        }
        void Cancel()
        {
            addcompanydata = new();
            StateHasChanged();
        }
        protected async void UpdateCompany(int CompId)
        {
            try
            {
                DepartmentList = await empployeeService.GetDepartments();
                addcompanydata = await companyService.GetCompanyAsync(CompId);
                //NavigationManager.NavigateTo("Employees");
                StateHasChanged();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected async void DeleteCompany(int CompId)
        {
            try
            {
                await companyService.DeleteCompanyAsync(CompId);
                NavigationManager.NavigateTo("Companies", true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
