namespace Service.Communication
{
    public class Response
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public Response()
        {
            Success = true;
            Message = string.Empty;
        }
        public Response(string message)
        {
            Success = false;
            Message = message;
        }
    }
    public class Response<T> : Response
    {
        public T Resource { get; private set; }

        public Response(T resource) : base()
        {
            Resource = resource;
        }

        public Response(string message) : base(message)
        {
            Resource = default;
        }
    } 
}