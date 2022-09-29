using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HR_SYSTEM.Pages
{
    public partial class Department
    {
        public List<SelectListItem> CompanyList = new();
        public List<HR_SYSTEM.Models.Department> Depob = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Depob = await departmentService.GetAllDepartmentsAsync();
            CompanyList = await departmentService.GetCompanies();

        }
    


     public   HR_SYSTEM.Models.Department obj1 = new();
        

        protected async void CreateDepartment()
        {

            await departmentService.InsertDeparmentAsync(obj1);
            NavigationManager.NavigateTo("Departments", true);

        }
        void Cancel()
        {
            obj1 = new();

            StateHasChanged();
        }
        protected async void UpdateDepartment(int DepId)
        {
            try
            {

                obj1 = await departmentService.GetDepartmentAsync(DepId);
                //NavigationManager.NavigateTo("Employees");
                StateHasChanged();
            }

            catch (Exception ex)
            {

                throw;
            }


        }
        protected async void DeleteDepartment(int DepId)
        {
            try
            {
                await departmentService.DeleteDepartmentAsync(DepId);
                NavigationManager.NavigateTo("Departments", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

