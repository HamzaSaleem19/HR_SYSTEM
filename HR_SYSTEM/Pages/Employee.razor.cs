using HR_SYSTEM.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using HR_SYSTEM.ViewModels;

namespace HR_SYSTEM.Pages
{
    public partial class Employee
    {
        [Inject]
        public IWebHostEnvironment Environment { get; set; }
        public string rootFolder = "";

        public bool IsBusy { get; set; }
        public List<SelectListItem> CompanyList = new();
        public List<SelectListItem> DepartmentList = new();
        public List<SelectListItem> RoleList = new();
        public EmployeePaginationVM singleRecord = new();
        public List<EmployeeVM> Empob = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public DepartmentService departmentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadRecord();
            //Empob = await employeeService.GetAllEmployeesAsync(dTO);
            CompanyList = await departmentService.GetCompanies();
            DepartmentList = await employeeService.GetDepartments();
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
                obj = new();
                DepartmentList = await employeeService.GetDepartments();
                obj = await employeeService.GetEmployeeAsync(EmpId);
                if (obj == null)
                    obj = new();
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

        public bool isLoading { get; set; }
        public List<String> ContacrPersonFileName { get; set; } = new();
        public string ErrorMessage = "";
        public long maxFileSize = 1024 * 15000;
        public int maxAllowedFiles = 5;
        private async Task ContactPersonLoadFiles(InputFileChangeEventArgs e)
        {
            isLoading = true;
            ContacrPersonFileName = new List<string>();
            // ContractorLocalFileName = new List<string>();
            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                try
                {
                    Stream stream = file.OpenReadStream(maxFileSize);
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();
                    if (File.Exists(Path.Combine(rootFolder, file.Name)))
                    {
                        var result = Path.GetFileName(file.Name);
                        var startIndex = result.LastIndexOf('.');
                        var filenamewithoutextension = result.Substring(0, startIndex);
                        var FileExtension = result.Substring(startIndex, 4);
                        var filename = filenamewithoutextension + "-" + DateTime.Now.ToString("ddmmyyyy") + FileExtension;
                        var path = Path.Combine(Environment.ContentRootPath, "wwwroot/Upload Images", filename);
                        await using FileStream fs = new(path, FileMode.Create);
                        await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
                        //FileName.Add(filename);
                        obj.FilePath = filename;

                    }
                    else
                    {
                        var result = Path.GetFileName(file.Name);

                        var startIndex = result.LastIndexOf('.');
                        var filenamewithoutextension = result.Substring(0, startIndex);
                        var FileExtension = result.Substring(startIndex, 4);
                        var filename = filenamewithoutextension + FileExtension;
                        var path = Path.Combine(Environment.ContentRootPath, "wwwroot/Upload Images", filename);
                        await using FileStream fs = new(path, FileMode.Create);
                        await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
                        obj.FilePath = filename;
                    }
                    StateHasChanged();
                }
                catch (Exception ex)
                {

                    ErrorMessage = ex.Message.ToString();
                    StateHasChanged();
                }

                isLoading = false;
            }


        }
        EmployeePaginationVM Epagination = new();
        PaginationDTO dTO = new();
        private async Task SelectedPage(int page)
        {
            /// Epagination.currentPage = page;
            await LoadRecord(page);
        }
        int totalcount = 0;
        public async Task LoadRecord(int page = 1, int quantityPerPage = 3)
        {
            Epagination = new();
            Epagination.currentPage = page;
            dTO = new PaginationDTO() { Page = page, QuantityPerPage = quantityPerPage };
            singleRecord = await employeeService.GetAllEmployeesAsync(dTO);
            if (singleRecord != null)
            {
                Empob = singleRecord.lstAllRecords;
                Epagination.TotalPages = singleRecord.TotalPages;
                totalcount = Epagination.TotalCount = singleRecord.TotalCount;

            }
            StateHasChanged();
        }
    }
}

