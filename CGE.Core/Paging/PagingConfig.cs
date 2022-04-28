namespace CGE.Core.Paging
{
    public sealed class PagingConfig
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PagingConfig(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
