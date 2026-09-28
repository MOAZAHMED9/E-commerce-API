using E_commerce_API.Models;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, int.MaxValue)]
        public int pagenumber { get; set; } = 1;
        [Range(1, 50)]
        public int pagesize { get; set; } = 10;

    }
}
