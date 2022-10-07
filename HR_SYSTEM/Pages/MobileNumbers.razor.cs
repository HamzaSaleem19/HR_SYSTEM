using HR_SYSTEM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace HR_SYSTEM.Pages
{
    public  partial class MobileNumbers
    {
        public List<SelectListItem> CompanyList = new();
        public List<SelectListItem> DepartmentList = new();
        public List<SelectListItem> EmployeeList = new();
        public List<HR_SYSTEM.Models.MobileNo> Mobileob = new();
        [Inject]
        public NavigationManager NavigationManager  { get; set; }
        [Inject]
        protected EmployeeService employeeService { get; set; }
        [Inject]
        public DepartmentService departmentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Mobileob = await mobileService.GetAllMobileNumbersAsync();
            // EmployeeList = await mobileService.GetEmployees();
            CompanyList = await departmentService.GetCompanies();

        }
        public async void GetDepartmentCompanywise(int companyid)
        {
            DepartmentList = new();
            EmployeeList= new();
            addnumber.CompanyRegNo = companyid;
            DepartmentList = await employeeService.GetDepartmentbyid(companyid);
            StateHasChanged();
        }
        public async void GetEmployeeDepartmentwise(int deptid)
        {
            EmployeeList = new();
            addnumber.DepId = deptid;
            EmployeeList = await employeeService.GetEmployeebyid(deptid);
            StateHasChanged();
        }
        public HR_SYSTEM.Models.MobileNo addnumber = new();
        protected async void CreateMobilenumber()
        {
            await mobileService.InsertMobilenumberAsync(addnumber);
            NavigationManager.NavigateTo("Mobile Numbers", true);

        }
        void Cancel()
        {
            addnumber = new();
            StateHasChanged();
        }
        protected async void UpdatMobileNumber(int MobileId)
        {
            try
            {
                addnumber = await mobileService.GetMobileNumberAsync(MobileId);
                DepartmentList = await employeeService.GetDepartments();
                EmployeeList = await employeeService.GetEmployees();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected async void DeleteMobileNumber(int MobileId)
        {
            try
            {
                await mobileService.DeleteNumberAsync(MobileId);
                NavigationManager.NavigateTo("Mobile Numbers", true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
    

