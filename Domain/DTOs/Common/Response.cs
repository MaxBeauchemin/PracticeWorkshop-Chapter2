namespace Domain.DTOs.Common
{
    public class Response<T>
    {
        public Response()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
