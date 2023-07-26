using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Models
{
    public class Booking
    {
        [Key]
        public int Book_Id { get; set; }
        public string? Booking_Person_Name { get; set; }

        public int Days { get; set; }
        public double Phone_Number { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Hotel? Hotel { get; set; }
        public Room? Room { get; set; }
        public Customer? Customer { get; set; }

    }
}
