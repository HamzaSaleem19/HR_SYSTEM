using HR_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HR_SYSTEM.Services
{
    public class RoleService
    {
        
            private readonly AppDBContext _appDBContext;
            public RoleService(AppDBContext appDBContext)
            {
                _appDBContext = appDBContext;
            }
            public async Task<List<Role>> GetAllRolesAsync()
            {
                return await _appDBContext.Roles.ToListAsync();
            }
            public async Task<bool> InsertRoleAsync(Role role)
            {
            try
            {
                if (role.RoleId == 0)
                {
                    await _appDBContext.Roles.AddAsync(role);
                }
                else
                {
                   var chechrolerecord= await _appDBContext.Roles.Where(x => x.RoleId == role.RoleId).FirstOrDefaultAsync();
                }

                await _appDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

                return true;
            }
        public async Task<Role> GetRoleAsync(int Id)//Get Role By Id
        {
            try
            {
                Role role = await _appDBContext.Roles.FirstOrDefaultAsync(c => c.RoleId.Equals(Convert.ToInt32(Id)));
                return role;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateRoleAsync(Role role) //update Role
        {
            try
            {
                _appDBContext.Roles.Update(role);
                await _appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> DeleteRoleAsync(int RoleId)//delete Role
        {
            var checkrolerecord = await _appDBContext.Roles.Where(x => x.RoleId == RoleId).FirstOrDefaultAsync();
            if (checkrolerecord != null)
            {
                _appDBContext.Roles.Remove(checkrolerecord);
                await _appDBContext.SaveChangesAsync();
            }

            return true;
        }
    }
    }

    
