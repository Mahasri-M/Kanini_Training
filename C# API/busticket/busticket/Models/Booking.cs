using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace busticket.Models
{
   
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public string? Passenger_Name { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public double? Mobile { get; set; }

       

       
    }
}
