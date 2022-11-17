using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class TehsilService
    {

        private readonly AppDBContext _appDBContext;

        public TehsilService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<bool> InsertTehsilAsync(TehsilViewModel tehsil)
        {
            try
            {
                Tehsil addtehsil = new()
                {
                    Name = tehsil.TehsilName,
                    DistrictId = tehsil.DistrictId,

                };
                await _appDBContext.Tehsils.AddAsync(addtehsil);
                await _appDBContext.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {

                return false;
            }

        }

        public async Task<List<SelectListItem>> GetDistrictbyid(int divisionId)
        {
            return await _appDBContext.Districts.Where(x => x.DivisionId == divisionId).Select(x => new SelectListItem()
            { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
        }
        public async Task<List<ListofTehsils>> GetAllTehsilsAsync()
        {
            return await (from c in _appDBContext.Countries
                          join p in _appDBContext.Provinces on c.Id equals p.CountryId
                          join d in _appDBContext.Divisions on p.Id equals d.ProvinceId
                          join dis in _appDBContext.Districts on d.Id equals dis.DivisionId
                          join teh in _appDBContext.Tehsils on dis.Id equals teh.DistrictId
                          select new ListofTehsils
                          {
                              Countryname = c.Name,
                              Provincename = p.Name,
                              Divisionname = d.Name,
                              Districtname = dis.Name,
                              Tehsilname = teh.Name,
                              TehsilId = teh.Id,
                          }).OrderByDescending(x => x.TehsilId).ToListAsync();
        }
    }
}
