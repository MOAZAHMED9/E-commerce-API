namespace E_commerce_API.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }


        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; } =false;
    }
}
