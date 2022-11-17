using HR_SYSTEM.Models;
using System.Threading.Tasks;

namespace HR_SYSTEM.Services
{
    public class AnrService
    {
        private readonly AppDBContext _appDBContext;

        public AnrService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<bool> InsertAnrAsync(ANR anr)
        {
            await _appDBContext.ANRs.AddAsync(anr);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
