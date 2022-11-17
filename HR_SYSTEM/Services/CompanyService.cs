using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HR_SYSTEM.Services
{
    public class CompanyService
    {
        private readonly AppDBContext _appDBContext;

        public CompanyService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            // return await _appDBContext.Companies.ToListAsync();
            return await (from c in _appDBContext.Companies
                          join d in _appDBContext.Departments on c.CompanyRegNo equals d.CompanyRegNo
                          select c).ToListAsync();

        }
        public async Task<bool> InsertCompanyAsync(Company company)
        {
            try
            {
                if (company.CompanyRegNo == 0)
                {
                    await _appDBContext.Companies.AddAsync(company);
                }
                else
                {
                    var checkcomprecord = await _appDBContext.Companies.Where(x => x.CompanyRegNo == company.CompanyRegNo).FirstOrDefaultAsync();
                }
                await _appDBContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
        public async Task<Company> GetCompanyAsync(int Id)//Get Company by Id
        {
            try
            {
                Company company = await _appDBContext.Companies.FirstOrDefaultAsync(c => c.CompanyRegNo.Equals(Id));
                return company;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateCompanyAsync(Company company) //update Company
        {
            try
            {
                _appDBContext.Companies.Update(company);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteCompanyAsync(int CompId)//delete Company
        {
            var checkcomprecord = await _appDBContext.Companies.Where(x => x.CompanyRegNo == CompId).FirstOrDefaultAsync();
            if (checkcomprecord != null)
            {
                _appDBContext.Companies.Remove(checkcomprecord);
                await _appDBContext.SaveChangesAsync();
            }

            return true;
        }
        public async Task<DashboardViewModel> GetDashboard()
        {
            DashboardViewModel d = new();
            d.CompanyCount = _appDBContext.Companies.Count();
            d.DepartmentCount = _appDBContext.Departments.Count();
            d.EmployeeCount = _appDBContext.Employees.Count();
            d.RoleCount = _appDBContext.Roles.Count();
            return d;
        }
    }
}