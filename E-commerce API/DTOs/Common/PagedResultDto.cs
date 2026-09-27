namespace E_commerce_API.DTOs.Common
{
    public class PagedResultDto<T>
    {
        public int pageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public ICollection<T> Data { get; set; }

    }
}
