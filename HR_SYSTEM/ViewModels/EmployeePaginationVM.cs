using System.Collections.Generic;

namespace HR_SYSTEM.ViewModels
{
    public class EmployeePaginationVM
    {
        public List<EmployeeVM> ProductsVmList { get; set; }
        public List<EmployeeVM> lstAllRecords { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int currentPage { get; set; } = 1;
    }
}
