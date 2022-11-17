using HR_SYSTEM.Services;
using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace HR_SYSTEM.Pages
{
    public partial class Index
    {
        [Inject]
        public CompanyService CompanyService { get; set; }
 
        public DashboardViewModel Dash = new();
        protected override async Task OnInitializedAsync()
        {
            await Dashboard();

        }
        public async Task Dashboard()
        {
            Dash = await companyService.GetDashboard();
        }
    }
}
