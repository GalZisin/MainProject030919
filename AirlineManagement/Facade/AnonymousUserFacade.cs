using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagement
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade, IFacade
    {
        /// <summary>
        /// Return list of airlinecompanies.
        /// </summary>
        /// <returns></returns>
        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAO.GetAll();
        }
        /// <summary>
        /// Return list of all flights.
        /// </summary>
        /// <returns></returns>
        public IList<Flight> GetAllFlights()
        {
            return _flightDAO.GetAll();
        }
        /// <summary>
        /// Return dictionary of vacancy by flight.
        /// </summary>
        /// <returns></returns>
        public Dictionary<Flight, int> GetAllFlightsByVacancy()
        {
            return _flightDAO.GetAllFlightsByVacancy();
        }
        /// <summary>
        /// Return flight by flight ID.
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Flight GetFlightById(long flightId)
        {
            return _flightDAO.Get(flightId);
        }
        /// <summary>
        /// Return list of flights by depatrure date.
        /// </summary>
        /// <param name="departureDate"></param>
        /// <returns></returns>
        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightsByDepartureDate(departureDate);
        }
        /// <summary>
        ///  Return list of flights by destination country.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public IList<Flight> GetFlightsByDestinationCountry(long countryCode)
        {
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }
        /// <summary>
        /// Return list of flights by landing date.
        /// </summary>
        /// <param name="landingDate"></param>
        /// <returns></returns>
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }
        /// <summary>
        /// Return list of flights by origin country code.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public IList<Flight> GetFlightsByOriginCountry(long countryCode)
        {
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }
    }
}
