using System.Collections.Generic;

namespace CoreAutoCrudApp.Data.Pagination
{
    public class PagedResult<T> : PagedResultBase
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
