namespace backend.DTOs.common
{
    public class ResultPaginationDTO<T>
    {
        public PaginationMeta Meta { get; set; } = new PaginationMeta();
        public List<T> Result { get; set; } = new List<T>();
    }

    public class PaginationMeta
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public long Total { get; set; }
    }
}
