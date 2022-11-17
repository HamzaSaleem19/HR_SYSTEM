using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class DivisionService
    {
        private readonly AppDBContext _appDBContext;

        public DivisionService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<bool> InsertDivisionAsync(DivisionViewModel division)
        {
            try
            {
                Division adddiv = new()
                {
                    Name = division.DivisionName,
                    ProvinceId = division.ProvinceId,
                    
                };
                await _appDBContext.Divisions.AddAsync(adddiv);
                await _appDBContext.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {

                return false;
            }

        }

        public async Task<List<SelectListItem>> GetProvincebyid(int countryId)
        {
            return await _appDBContext.Provinces.Where(x => x.CountryId == countryId).Select(x => new SelectListItem()
            { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
        }
        public async Task<List<ListofDivisions>> GetAllDivisionsAsync()
        {
            return await (from c in _appDBContext.Countries
                          join p in _appDBContext.Provinces on c.Id equals p.CountryId
                          join d in _appDBContext.Divisions on p.Id  equals d.ProvinceId
                          select new ListofDivisions
                          {
                              Countryname = c.Name,
                              Provincename = p.Name,
                              Divisionname = d.Name,
                              Divisionid = d.Id
                          }).OrderByDescending(x => x.Divisionid).ToListAsync();
        }
    }

}
