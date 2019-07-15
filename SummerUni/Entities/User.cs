

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerUni.Entities
{
    public class User
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }
        public Cart Cart { get; set; } = new Cart();
        
    }
}