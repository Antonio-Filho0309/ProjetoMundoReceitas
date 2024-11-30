using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Pagination;

namespace ProjetoMundoReceitas.Helpers
{
    public static class PageBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PageBaseRequest request)
       where TResponse : PageBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);
            response.TotalRegisters = count;

            if (!string.IsNullOrEmpty(request.OrderByProperty))
            {
                query = query.OrderByDynamic(request.OrderByProperty);
            }

            response.Data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return response;
        }
        private static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string propertyName)
        {
            return query.OrderBy(x => EF.Property<object>(x, propertyName));
        }
    }


}
