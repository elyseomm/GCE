using System.Linq;

namespace CGE.Core.Paging
{
    public static class PagingExtensions
    {
        public static PagedResult<T> ToPagedResult<T>(this IQueryable<T> query, PagingConfig config)
            where T : class
        {
            var totalCount = query.Count();

            var items = query
                .Skip((config.PageIndex - 1) * config.PageSize)
                .Take(config.PageSize)
                .ToList();


            return new PagedResult<T>(config, items, totalCount);
        }
    }
}
