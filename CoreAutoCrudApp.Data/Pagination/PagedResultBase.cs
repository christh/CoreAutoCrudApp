using System;

namespace CoreAutoCrudApp.Data.Pagination
{
    public abstract class PagedResultBase
    {
        public int ActivePage { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int RowCount { get; set; }
        public string LinkTemplate { get; set; }

        public int FirstRowOnPage
        {

            get { return (ActivePage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(ActivePage * PageSize, RowCount); }
        }
    }
}
