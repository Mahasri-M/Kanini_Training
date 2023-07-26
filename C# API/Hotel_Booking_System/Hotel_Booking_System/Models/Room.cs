using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }

        public string? Room_Type { get; set; }

        public string? Room_Status { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
