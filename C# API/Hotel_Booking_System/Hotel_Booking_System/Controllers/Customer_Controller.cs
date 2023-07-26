using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories.Customer_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Hotel_Booking_System.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_Controller : ControllerBase
    {
        private readonly ICustomer cus;
        public Customer_Controller(ICustomer cus)
        {
            this.cus = cus;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cus.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            return cus.GetCustomersById(id);
        }

        [HttpPost]
        public Customer PostCustomer(Customer Customer)
        {
            return cus.PostCustomer(Customer);
        }
        [HttpPut("{id}")]
        public Customer PutCustomer(int id, Customer Customer)
        {
            return cus.PutCustomer(id, Customer);
        }
        [HttpDelete("{id}")]
        public Customer DeleteCustomer(int id)
        {
            return cus.DeleteCustomer(id);
        }
        [HttpGet("location")]
        public IEnumerable<Hotel> FilterLocation(string location)
        {
            return cus.FilterLocation(location);
        }
        [HttpGet("amenities")]
        public IEnumerable<Hotel> FilterAmenities(string amenities)
        {
            return cus.FilterAmenities(amenities);
        }
        [HttpGet("pricerange")]
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            return cus.FilterPriceRange(minPrice, maxPrice);
        }
        [HttpGet("availability")]
        public int GetAvailableRoomCount(int hotel_Id)
        {
            return cus.GetAvailableRoomCount(hotel_Id);
        }
    }
}
