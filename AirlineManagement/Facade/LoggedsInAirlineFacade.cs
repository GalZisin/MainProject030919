using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagement
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade, IFacade
    {
        /// <summary>
        /// Cancel flight by using a given flight.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flight"></param>
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _ticketDAO.RemoveTicketsByFlightId(flight.ID);
                _flightDAO.Remove(flight);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Change to new password by using old password. 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if (token != null)
            {
                if (token.User.PASSWORD == oldPassword)
                {
                    token.User.PASSWORD = newPassword;
                    _airlineDAO.Update(token.User);
                }
                else
                {
                    throw new NotValidPasswordException("Wrong Password");
                }
            }
              
        }
        /// <summary>
        /// Create new flight with given flight data.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flight"></param>
        public long CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                return _flightDAO.Add(flight);
            }
            else
                throw new Exception("Token can't be null");

        }
        /// <summary>
        /// Return list of all flights by Company ID.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Flight> GetAllFlightsByCompanyId(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _flightDAO.GetFlightsByAirlineCompanyId(token.User.ID);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return list of all flights.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _flightDAO.GetAll();
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return list of all tickets.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _ticketDAO.GetAll();
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return list of all airline company ID.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Ticket> GetAllTicketsByAirlineCompanyId(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _ticketDAO.GetTicketsByAirlineCompanyId(token.User.ID);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Modify airline details by using modified airline data.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="airline"></param>
        public void ModifyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO.Update(airline);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Update flight by using modified or new flight data.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flight"></param>
        /// 
        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Update(flight);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Update remaining tickets
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flight"></param>
        public void UpdateRemainingTickets(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Update(flight);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return flight by flight ID.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Flight GetFlightByFlightId(LoginToken<AirlineCompany> token, long flightId)
        {
            if (token != null)
            {
                return _flightDAO.Get(flightId);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get country by country name
        /// </summary>
        /// <param name="token"></param>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public Country GetCountryByName(LoginToken<AirlineCompany> token, string countryName)
        {
            if (token != null)
            {
                return _countryDAO.GetCountryByName(countryName);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get customer by customer user name
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customerUserName"></param>
        /// <returns></returns>
        public Customer GetCustomerByUserName(LoginToken<AirlineCompany> token, string customerUserName)
        {
            if (token != null)
            {
                return _customerDAO.GetCustomerByUsername(customerUserName);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get customer by custome first name
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public Customer GetCustomerByName(LoginToken<AirlineCompany> token, string customerName)
        {
            if (token != null)
            {
                return _customerDAO.GetCustomerByName(customerName);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get ticket by customer ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Ticket GetTicketByCustomerId(LoginToken<AirlineCompany> token, long customerId)
        {
            if (token != null)
            {
                return _ticketDAO.GetTicketByCustomerId(customerId);
            }
            else
                throw new Exception("Token can't be null");
        }
        
    }
}
