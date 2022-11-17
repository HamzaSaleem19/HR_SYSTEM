using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class DistrictService
    {
        private readonly AppDBContext _appDBContext;

        public DistrictService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<bool> InsertDistrictAsync(DistrictViewModel district)
        {
            try
            {
                District adddist = new()
                {
                    Name = district.DistrictName,
                    DivisionId = district.DivisionId,

                };
                await _appDBContext.Districts.AddAsync(adddist);
                await _appDBContext.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {

                return false;
            }

        }

        public async Task<List<SelectListItem>> GetDivisionbyid(int provinceId)
        {
            return await _appDBContext.Divisions.Where(x => x.ProvinceId == provinceId).Select(x => new SelectListItem()
            { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
        }
        public async Task<List<ListofDistricts>> GetAllDistrictsAsync()
        {
            return await (from c in _appDBContext.Countries
                          join p in _appDBContext.Provinces on c.Id equals p.CountryId
                          join d in _appDBContext.Divisions on p.Id equals d.ProvinceId
                          join dis in _appDBContext.Districts on d.Id equals dis.DivisionId
                          select new ListofDistricts
                          {
                              Countryname = c.Name,
                              Provincename = p.Name,
                              Divisionname = d.Name,
                              Districtname = dis.Name,
                              DistrictId = dis.Id
                          }).OrderByDescending(x => x.DistrictId).ToListAsync();
        }
    }
}
