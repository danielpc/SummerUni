using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SummerUni.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}