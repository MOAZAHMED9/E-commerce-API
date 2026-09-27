using E_commerce_API.Models;
using System.Numerics;

namespace E_commerce_API.DTOs.Product
{
    public class ProductSearchQuereDto
    {
        public string? Search {  get; set; }
        public int? id { get; set; }
        public decimal? minprice { get; set; }
        public decimal? maxprice { get; set; }

        public string? orderby { get; set; }
        public bool desc {  get; set; } = false;
        public bool isAvailable { get; set; } = true;

        public int pagenumber { get; set; }
        public int pagesize { get; set; }

    }
}
