using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.Customer_Repositories
{
    public class Customer_Repository:ICustomer
    {
        private readonly HotelContext _CustomerContext;
        public Customer_Repository(HotelContext context)
        {
            _CustomerContext = context;
        }
        //GetAllCustomer
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _CustomerContext.Customers.ToList();
        }
        //GetCustomerById
        public Customer GetCustomersById(int Customer_Id)
        {
            return _CustomerContext.Customers.FirstOrDefault(x => x.Customer_Id == Customer_Id);
        }
        //PostCustomer
        public Customer PostCustomer(Customer Customer)
        {
            var emp = _CustomerContext.Hotels.Find(Customer.Hotel.Hotel_Id);
            Customer.Hotel = emp;
            _CustomerContext.Add(Customer);
            _CustomerContext.SaveChanges();
            return Customer;
        }
        //PutCustomer
        public Customer PutCustomer(int Customer_Id, Customer Customer)
        {
            var emp = _CustomerContext.Hotels.Find(Customer.Hotel.Hotel_Id);
            Customer.Hotel = emp;
            _CustomerContext.Entry(Customer).State = EntityState.Modified;
            _CustomerContext.SaveChangesAsync();
            return Customer;
        }
        //DeleteCustomer
        public Customer DeleteCustomer(int Customer_Id)
        {
            var emp = _CustomerContext.Customers.Find(Customer_Id);
            _CustomerContext.Customers.Remove(emp);
            _CustomerContext.SaveChanges();
            return emp;
        }
        //Filtering location
        public IEnumerable<Hotel> FilterLocation(string location)
        {
            try
            {
                var location_query = _CustomerContext.Hotels.Include(x => x.Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(location))
                {
                    location_query = location_query.Where(h => h.Hotel_Location.Contains(location));
                }
                return location_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the location.", ex);
            }
        }
        //Filtering amenities
        public IEnumerable<Hotel> FilterAmenities(string amenities)
        {
            try
            {
                var amenities_query = _CustomerContext.Hotels.Include(x => x.Rooms).AsQueryable();

                if (!string.IsNullOrEmpty(amenities))
                {
                    amenities_query = amenities_query.Where(h => h.Amenities.Contains(amenities));
                }
                return amenities_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the amenties.", ex);
            }
        }
        // Filtering price range
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var priceQuery = _CustomerContext.Hotels.Include(x => x.Rooms).AsQueryable();

                if (minPrice > 0)
                {
                    priceQuery = priceQuery.Where(r => r.Price >= minPrice);
                }

                if (maxPrice > 0)
                {
                    priceQuery = priceQuery.Where(r => r.Price <= maxPrice);
                }

                return priceQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the price range.", ex);
            }
        }
        //Check room availability
        public int GetAvailableRoomCount(int hotel_Id)
        {
            try
            {
                return _CustomerContext.Rooms.Count(r => r.Hotel.Hotel_Id == hotel_Id && r.Room_Status == "available");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the count of available rooms.", ex);
            }
        }

    }
}
 