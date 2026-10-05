using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public class Categore : BaseEntity
    {
        
        public string Name { get; set; } 

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
