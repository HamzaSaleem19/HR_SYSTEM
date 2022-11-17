using HR_SYSTEM.Models;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class ProvinceService
    {
        private readonly AppDBContext _appDBContext;

        public ProvinceService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<bool> InsertProvinceAsync(ProvinceVeiwModel province)
        {
            try
            {
                Province addpro = new()
                {
                    Name = province.Provincename,
                    CountryId = province.CountryId,
                };
                await _appDBContext.Provinces.AddAsync(addpro);
                await _appDBContext.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {

                return false;
            }
          
        }
        public async Task<List<SelectListItem>> GetCountries()
        {
            return await _appDBContext.Countries.Select(x => new SelectListItem()
            { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
        }
        public async Task<List<ListofProvince>> GetAllProvincesAsync()
        {
            return await  (from p in _appDBContext.Provinces
                            join c in _appDBContext.Countries on p.CountryId equals c.Id
                            select new ListofProvince
                            {
                                Countryname=c.Name,
                                Provincename=p.Name,
                                Provinceid=p.Id
                            }).OrderByDescending(x => x.Provinceid).ToListAsync();
        }
    }
}
