using HR_SYSTEM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace HR_SYSTEM.Pages
{
    public partial class Employee
    {
        public List<SelectListItem> CompanyList = new();
        public List<SelectListItem> DepartmentList = new();
        public List<SelectListItem> RoleList = new();
        public List<HR_SYSTEM.Models.Employee> Empob = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public DepartmentService departmentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Empob = await employeeService.GetAllEmployeesAsync();
            CompanyList = await departmentService.GetCompanies();
            // DepartmentList = await employeeService.GetDepartments();
            RoleList = await employeeService.GetRoles();
        }
        public async void GetDepartmentCompanywise(int companyid)
        {
            DepartmentList = new();
            obj.CompanyRegNo = companyid;
            DepartmentList = await employeeService.GetDepartmentbyid(companyid);
            StateHasChanged();
        }
        HR_SYSTEM.Models.Employee obj = new();
        protected async void CreateEmployee()
        {
            try
            {
                await employeeService.InsertEmployeeAsync(obj);
                NavigationManager.NavigateTo("Employees", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        void Cancel()
        {
            obj = new();
            StateHasChanged();
        }
        protected async void UpdateEmployee(int EmpId)
        {
            try
            {
                DepartmentList = await employeeService.GetDepartments();
                obj = await employeeService.GetEmployeeAsync(EmpId);
                //NavigationManager.NavigateTo("Employees");
                StateHasChanged();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected async void DeleteEmployee(int EmpId)
        {
            try
            {
                await employeeService.DeleteEmployeeAsync(EmpId);
                NavigationManager.NavigateTo("Employees", true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

