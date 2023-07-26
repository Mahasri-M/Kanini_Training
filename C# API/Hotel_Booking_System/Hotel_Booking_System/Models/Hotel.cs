using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }

        public string? Hotel_Name { get; set; }

        public string? Hotel_Location { get; set; }

        public string? Amenities { get; set; }

        public int? Price { get; set; }

        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
