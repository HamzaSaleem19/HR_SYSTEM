
using HR_SYSTEM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class MobileService
    {
        private readonly AppDBContext _appDBContext;

        public MobileService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<List<MobileNo>> GetAllMobileNumbersAsync()
        {
            try
            {
                var mobilenumbers = await _appDBContext.MobileNumbers.Include(e => e.Employee).ToListAsync();
                return mobilenumbers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<MobileNo> GetMobileNumberAsync(int Id)//Get MobileNumber By Id
        {
            try
            {
                MobileNo mobileno = await _appDBContext.MobileNumbers.FirstOrDefaultAsync(c => c.MobileId.Equals(Convert.ToInt32(Id)));
                return mobileno;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdatMobileNumberAsync(MobileNo mobileno) //update 
        {
            try
            {
                _appDBContext.MobileNumbers.Update(mobileno);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteNumberAsync(int MobileId)//delete 
        {
            var checknumberrecord = await _appDBContext.MobileNumbers.Where(x => x.MobileId == MobileId).FirstOrDefaultAsync();
            if (checknumberrecord != null)
            {
                _appDBContext.MobileNumbers.Remove(checknumberrecord);
                await _appDBContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> InsertMobilenumberAsync(MobileNo mobileno)
        {
            try
            {
                if (mobileno.MobileId == 0)
                {
                    await _appDBContext.MobileNumbers.AddAsync(mobileno);
                }
                else
                {
                    var checknumberrecord = await _appDBContext.MobileNumbers.Where(x => x.MobileId == mobileno.MobileId).FirstOrDefaultAsync();
                }

                await _appDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
        public async Task<List<SelectListItem>> GetEmployees()
        {
            return await _appDBContext.Employees.Select(x => new SelectListItem()
            { Value = x.EmpId.ToString(), Text = x.Name }).ToListAsync();
        }
    }

}
