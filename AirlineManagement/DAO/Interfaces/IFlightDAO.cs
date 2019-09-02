using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagement
{
    public interface IFlightDAO : IBasicDB<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsByVacancy();
        //Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(long countryCode);
        IList<Flight> GetFlightsByDestinationCountry(long countryCode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);
        IList<Flight> GetFlightsByAirlineCompanyId(long airlineCompanyId);
        IList<Flight> GetFlightsByCustomerId(long CustomerId);
        void UpdateRemainingTickets(long flightId);
        int GetReminingTickets(long flightId);
        void RemoveFlightsByAirlineCompanyId(long airlineCompamyId);
        void RemoveFlightsByCountryCode(long countryCode);
        IList<Flight> GetFlightsByCustomerUserName(string customerUserName);
        


    }
}
