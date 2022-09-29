using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HR_SYSTEM.Pages
{
    public partial class Roles
    {

        public List<HR_SYSTEM.Models.Role> Roleob = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Roleob = await roleService.GetAllRolesAsync();
        }
        public HR_SYSTEM.Models.Role addrole = new();
        protected async void CreateRole()
        {
            await roleService.InsertRoleAsync(addrole);
            NavigationManager.NavigateTo("Roles", true);

        }
        void Cancel()
        {
            addrole = new();

            StateHasChanged();
        }
        protected async void UpdateRole(int RoleId)
        {
            try
            {
                
                addrole = await roleService.GetRoleAsync(RoleId);
                //NavigationManager.NavigateTo("Employees");
                StateHasChanged();
            }

            catch (Exception ex)
            {

                throw;
            }


        }
        protected async void DeleteRole(int RoleId)
        {
            try
            {
                await roleService.DeleteRoleAsync(RoleId);
                NavigationManager.NavigateTo("Roles", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
