using System.ComponentModel.DataAnnotations;

namespace busticket.Models
{
    public class Busdetails
    {
        [Key]
        public int BusId { get; set; }

        public string? Busname { get; set; }
    
        public int price { get; set; }

        public string? type { get; set; }

        public string? timing { get; set; }

        public string? boarding { get; set; }

        public string? destination { get; set; }

    }
}
