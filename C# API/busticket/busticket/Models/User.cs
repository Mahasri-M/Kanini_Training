
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace busticket.Models
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }
        public double? Mobile { get; set; }

        public string? Pwd { get; set; }
       
     
         
       
    }
}
