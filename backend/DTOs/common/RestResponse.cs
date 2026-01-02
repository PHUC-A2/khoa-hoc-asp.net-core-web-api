namespace backend.DTOs.common
{
    public class RestResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
