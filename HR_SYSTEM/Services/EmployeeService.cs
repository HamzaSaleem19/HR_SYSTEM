using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_SYSTEM.Helper;
using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace HR_SYSTEM.Services
{
    public class EmployeeService : ControllerBase
    {
        private readonly AppDBContext _appDBContext;

        public EmployeeService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        /// <summary>
        /// Get list of employees
        /// </summary>
        /// <returns></returns>
        public async Task<EmployeePaginationVM> GetAllEmployeesAsync([FromQuery] PaginationDTO pdto)
        {
            try
            {
               // await Task.Delay(9000);//Loader
                EmployeePaginationVM Epm = new();
                var queryable = _appDBContext.Employees.Include(d => d.MobileNos).Include(d => d.Department).Include(c => c.Department.Company).Include(r => r.Role).Select(x => new EmployeeVM()
                {
                    EmpId=x.EmpId,
                    Name = x.Name,
                    Cnic = x.Cnic,
                    Gender = x.Gender,
                    Address = x.Address,
                    Department = x.Department.DepName,
                    Role = x.Role.RoleType,
                    Company = x.Department.Company.Name,
                    MobileNumber = String.Join(",  ", x.MobileNos.Select(x => x.MobileNumber).ToArray()),
                    SingleMB = x.MobileNos.OrderByDescending(x =>x.MobileId).Select(x => x.MobileNumber).FirstOrDefault(),
                    FilePath = x.FilePath

                });
                //foreach (var item in queryable)
                //{
                //    foreach (var item1 in item.MobileNos)
                //    {

                //        item.MobileNumber += String.Join(",  " ,"  "+item1.MobileNumber);
                //    }
                //}
                //var Listofemployee = (from e in _appDBContext.Employees
                //                      join m in _appDBContext.MobileNumbers on e.EmpId equals m.EmpId
                //                      join d in _appDBContext.Departments on e.DepId equals d.DepId
                //                      join c in _appDBContext.Companies on d.CompanyRegNo equals c.CompanyRegNo
                //                      join r in _appDBContext.Roles on e.RoleId equals r.RoleId
                //                      select new EmployeeVM()
                //                      {
                //                          Name = e.Name,
                //                          Cnic = e.Cnic,
                //                          Gender = e.Gender,
                //                          Address = e.Address,
                //                          Role = r.RoleType,
                //                          Company = c.Name,
                //                          MobileNumber = m.MobileNumber,
                //                          Department=d.DepName,
                //                          FilePath=e.FilePath

                //                      });



                Epm.TotalPages = await HttpContext.InsertPaginationParameterInResponse(queryable, pdto.QuantityPerPage);
                Epm.lstAllRecords = await queryable.Paginate(pdto).ToListAsync();
                // Epm.All = queryable.ToList();
                Epm.TotalCount = queryable.Count();


                return Epm;
            }

            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            try
            {
                if (employee.EmpId == 0)
                {
                    await _appDBContext.Employees.AddAsync(employee);
                }
                else
                {
                    var checkemployeerecord = await _appDBContext.Employees.Where(x => x.EmpId == employee.EmpId).FirstOrDefaultAsync();
                }
                await _appDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }

        public async Task<List<SelectListItem>> GetDepartments()
        {
            return await _appDBContext.Departments.Select(x => new SelectListItem()
            { Value = x.DepId.ToString(), Text = x.DepName }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetRoles()
        {
            return await _appDBContext.Roles.Select(x => new SelectListItem()
            { Value = x.RoleId.ToString(), Text = x.RoleType }).ToListAsync();
        }


        public async Task<List<SelectListItem>> GetDepartmentbyid(int companyid)
        {
            return await _appDBContext.Departments.Where(x => x.CompanyRegNo == companyid).Select(x => new SelectListItem()
            { Value = x.DepId.ToString(), Text = x.DepName }).ToListAsync();
        }


        public async Task<List<SelectListItem>> GetEmployeebyid(int deptid)
        {
            return await _appDBContext.Employees.Where(x => x.DepId == deptid).Select(x => new SelectListItem()
            { Value = x.EmpId.ToString(), Text = x.Name }).ToListAsync();
        }
        public async Task<List<SelectListItem>> GetEmployees()
        {
            return await _appDBContext.Employees.Select(x => new SelectListItem()
            { Value = x.EmpId.ToString(), Text = x.Name }).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int Id)//Get Employee by Id
        {
            try
            {
                Employee employee = await _appDBContext.Employees.FirstOrDefaultAsync(c => c.EmpId.Equals(Convert.ToInt32(Id)));
                return employee;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateEmployeeAsync(Employee employee) //update Employee
        {
            try
            {
                _appDBContext.Employees.Update(employee);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteEmployeeAsync(int EmpId)//delete Employee
        {
            var checkemployeerecord = await _appDBContext.Employees.Where(x => x.EmpId == EmpId).FirstOrDefaultAsync();
            if (checkemployeerecord != null)
            {
                _appDBContext.Employees.Remove(checkemployeerecord);
                await _appDBContext.SaveChangesAsync();
            }

            return true;
        }
    }
}


