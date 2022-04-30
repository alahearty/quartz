namespace quartz.api
{
    public class Envelope<T>
    {
        public string Status { get; }
        public T Data { get; }
        public string Message { get; }

        public Envelope(string message, string status, T data)
        {
            Message = message;
            Status = status;
            Data = data;
        }
    }

    public class ResponseBody
    {
        public static Envelope<object> Error(string message)
        {
            return new Envelope<object>(message, "fail", null);
        }
        public static Envelope<T> Ok<T>(T data)
        {
            return new Envelope<T>(null, "success", data);
        }
    }
}
