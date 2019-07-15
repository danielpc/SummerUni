using System.ComponentModel.DataAnnotations;

namespace SummerUni.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}