using busticket.Models;
using Microsoft.EntityFrameworkCore;

namespace busticket.Services.BusRepo
{
    public class BusService:IBus
    {
        private readonly BusContext _UserContext;
        public BusService(BusContext context)
        {
            _UserContext = context;
        }
        //GetAllBuses
        public IEnumerable<Busdetails> GetAllBuses()
        {
            return _UserContext.Busdetailss.ToList();
        }
        //GetBusById
        public Busdetails GetBusById(int BusId)
        {
            return _UserContext.Busdetailss.FirstOrDefault(x => x.BusId == BusId);
        }
        //PostBus
        public async Task<List<Busdetails>> AddBusDetails(Busdetails busdetails)
        {
            _UserContext.Busdetailss.Add(busdetails);
            await _UserContext.SaveChangesAsync();

            return await _UserContext.Busdetailss.ToListAsync();
        }
        //Put
        public async Task<List<Busdetails>?> UpdateBusDetailsById(int id, Busdetails busdetails)
        {
            var users = await _UserContext.Busdetailss.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            users.Busname = busdetails.Busname;
            users.price = busdetails.price;
            users.type = busdetails.type;
            users.timing = busdetails.timing;
            users.destination = busdetails.destination;
            users.boarding = busdetails.boarding;

            await _UserContext.SaveChangesAsync();
            return await _UserContext.Busdetailss.ToListAsync();
        }
        //Delete
        public async Task<List<Busdetails>?> DeleteBusDetailsById(int id)
        {
            var users = await _UserContext.Busdetailss.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _UserContext.Remove(users);
            await _UserContext.SaveChangesAsync();
            return await _UserContext.Busdetailss.ToListAsync();
        }

        //filterbus by destination and boarding
        //public IEnumerable<Busdetails> FilterBoardingAndDestination(string boarding, string destination)
        //{
        //    try
        //    {
        //        var query = _UserContext.Busdetailss.AsQueryable();

        //        if (!string.IsNullOrEmpty(boarding))
        //        {
        //            query = query.Where(h => h.boarding.Contains(boarding));
        //        }

        //        if (!string.IsNullOrEmpty(destination))
        //        {
        //            query = query.Where(h => h.destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
        //        }

        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while filtering the amenities and location.", ex);
        //    }
        //}

        public IEnumerable<Busdetails> FilterByBoardingAndDestination(string boarding, string destination)
        {
            try
            {
                var query = _UserContext.Busdetailss.AsQueryable();

                if (!string.IsNullOrEmpty(boarding))
                {
                    query = query.Where(b => b.boarding.Contains(boarding));
                }

                if (!string.IsNullOrEmpty(destination))
                {
                    query = query.AsEnumerable().Where(b => b.destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).AsQueryable();
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering by boarding and destination.", ex);
            }
        }


    }
}
