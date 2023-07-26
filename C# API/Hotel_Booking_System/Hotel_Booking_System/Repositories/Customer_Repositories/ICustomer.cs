using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories.Customer_Repositories
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomersById(int Customer_Id);
        public Customer PostCustomer(Customer Customer);
        public Customer PutCustomer(int Customer_Id, Customer Customer);
        public Customer DeleteCustomer(int Customer_Id);
        public IEnumerable<Hotel> FilterLocation(string location);
        public IEnumerable<Hotel> FilterAmenities(string amenities);
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice);
        public int GetAvailableRoomCount(int hotel_Id);
    }
}
