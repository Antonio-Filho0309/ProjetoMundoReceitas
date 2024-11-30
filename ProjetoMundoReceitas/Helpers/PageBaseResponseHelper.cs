using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Pagination;

namespace ProjetoMundoReceitas.Helpers
{
    public static class PageBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PageBaseRequest request) where TResponse : PageBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Abs((double)count / request.PageSize);
            response.TotalRegisters = count;
            if (string.IsNullOrEmpty(request.OrderByProperty))
                response.Data = await query.ToListAsync();
            else
                response.Data = query.OrdeByDynamic(request.OrderByProperty)
                    .Skip((request.PageSize - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

            return response;
        }
        
        private static IEnumerable<T> OrdeByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }


}
