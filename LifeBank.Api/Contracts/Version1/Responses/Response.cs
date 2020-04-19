namespace LifeBank.Application.Common.Models.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }

        public Response() { }

        public Response(T response)
        {
            Data = response;
        }
    }
}
