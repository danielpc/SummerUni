using System.ComponentModel.DataAnnotations;

namespace SummerUni.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}