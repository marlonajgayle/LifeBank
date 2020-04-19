namespace LifeBank.Application.Pagination
{
    public class PaginationFilter
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public PaginationFilter(int page, int size)
        {
            Page = page;
            Size = (size > 50) ? 50 : size;
        }
    }
}
