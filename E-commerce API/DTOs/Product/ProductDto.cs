namespace E_commerce_API.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public decimal? quantity { get; set; }
        public bool isActive { get; set; }
        public string Categoryname { get; set; }

    }
}
