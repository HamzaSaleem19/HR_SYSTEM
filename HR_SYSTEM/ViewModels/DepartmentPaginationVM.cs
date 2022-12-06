using System.Collections.Generic;

namespace HR_SYSTEM.ViewModels
{
    public class DepartmentPaginationVM
    {
        public List<DepartmentVM> ProductsVmList { get; set; }
        public List<DepartmentVM> lstAllRecords { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int currentPage { get; set; } = 1;
    }
}
