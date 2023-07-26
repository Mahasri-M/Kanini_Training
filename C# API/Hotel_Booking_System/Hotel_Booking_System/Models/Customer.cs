using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        public string? Customer_Name { get; set; }

        public int Age { get; set; }

        public string? Customer_Email { get; set; }

        public double Phone_Number { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
