namespace backend.DTOs.common
{
    public class RestResponse<T>
    {
        public int StatusCode { get; set; }
        public object? Error { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
