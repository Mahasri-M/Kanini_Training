using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        public string? Employee_Name { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
