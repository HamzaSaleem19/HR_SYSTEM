using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace HR_SYSTEM.Services
{
    public class DepartmentService
    {
        private readonly AppDBContext _appDBContext;
        
        public DepartmentService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<DepartmentPaginationVM> GetAllDepartmentsAsync([FromQuery] PaginationDTO pdto)
        {
            return await _appDBContext.Departments.Include(x => x.Company).ToListAsync();
        }

        public async Task<bool> InsertDeparmentAsync(Department department)
        {
            try
            {
                if (department.DepId == 0)
                {
                    await _appDBContext.Departments.AddAsync(department);
                }
                else
                {
                    var checkdeprecord = await _appDBContext.Departments.Where(x => x.DepId == department.DepId).FirstOrDefaultAsync();
                }
                await _appDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
        public async Task<List<SelectListItem>> GetCompanies()
        {
            return await _appDBContext.Companies.Select(x => new SelectListItem()
            { Value = x.CompanyRegNo.ToString(), Text = x.Name }).ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(int Id)//Get Department by Id
        {
            try
            {
                Department department = await _appDBContext.Departments.FirstOrDefaultAsync(c => c.DepId.Equals(Convert.ToInt32(Id)));
                return department;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateDepartmentAsync(Department department) //update Derpartment
        {
            try
            {
                _appDBContext.Departments.Update(department);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteDepartmentAsync(int DepId)//delete Department
        {
            var checkdeprecord = await _appDBContext.Departments.Where(x => x.DepId == DepId).FirstOrDefaultAsync();
            if (checkdeprecord != null)
            {
                _appDBContext.Departments.Remove(checkdeprecord);
                await _appDBContext.SaveChangesAsync();
            }

            return true;
        }

    }
}