using busticket.Models;

namespace busticket.Services.BusRepo
{
    public interface IBus
    {
        public IEnumerable<Busdetails> GetAllBuses();
        public Busdetails GetBusById(int User_Id);
        Task<List<Busdetails>> AddBusDetails(Busdetails busdetails);
        Task<List<Busdetails>?> UpdateBusDetailsById(int id, Busdetails busdetails);
        Task<List<Busdetails>?> DeleteBusDetailsById(int id);

        IEnumerable<Busdetails> FilterByBoardingAndDestination(string boarding, string destination);
    }
}
