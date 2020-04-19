namespace LifeBank.Api.Contracts.Version1.Requests
{
    public class PaginationRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public PaginationRequest()
        {
            Page = 1;
            Size = 25;
        }

        public PaginationRequest(int page, int size)
        {
            Page = page;
            Size = (size > 50) ? 50 : size;
        }
    }
}
