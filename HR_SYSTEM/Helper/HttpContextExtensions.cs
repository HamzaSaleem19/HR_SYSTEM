using HR_SYSTEM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HR_SYSTEM.Helper
{
    public static class  HttpContextExtensions
    {
        public static async Task<int> InsertPaginationParameterInResponse<T>(this HttpContext httpContext, IQueryable<T> queryable, int recordsPerPage)
        {
            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / recordsPerPage);
            return Convert.ToInt32(pagesQuantity);
            // httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
             PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.QuantityPerPage)
                .Take(pagination.QuantityPerPage);
        }
    }
}
