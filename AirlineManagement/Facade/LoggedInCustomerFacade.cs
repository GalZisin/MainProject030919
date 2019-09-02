using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagement
{
    public class LoggedInCustomerFacade : AnonymousUserFacade, ILoggedInCustomerFacade, IFacade
     {
        private static void AddToLogFile(string str)
        {
            DateTime dt = DateTime.Now;
            string ll = dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString();
            string path = @"C:\Log\myUnitCustomerTestLog.txt";

            TextWriter writer = new StreamWriter(path, true);
            writer.WriteLine(ll + " " + str);
            writer.Close();
        }
        /// <summary>
        /// Cancel Ticket by using given ticket.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ticket"></param>
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token != null)
            {
                Flight f = _flightDAO.Get(ticket.FLIGHT_ID);
                f.REMANING_TICKETS++;
                _flightDAO.Update(f);
                _ticketDAO.Remove(ticket);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get all flights
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Flight> GetAllFlights(LoginToken<Customer> token)
        {
            if (token != null)
            {
                return _flightDAO.GetAll();
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return list of all customer flights.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token, string customerUserName)
        {
            if (token != null)
            {
                return _flightDAO.GetFlightsByCustomerUserName(customerUserName);
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
        public Ticket GetTicketByCustomerId(LoginToken<Customer> token, long customerId)
        {
            if (token != null)
            {
                return _ticketDAO.GetTicketByCustomerId(customerId);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get ticket by customer user name
        /// </summary>
        /// <param name="token"></param>
        /// <param name="customerUserName"></param>
        /// <returns></returns>
        public Ticket GetTicketByCustomerUserName(LoginToken<Customer> token, string customerUserName)
        {
            if (token != null)
            {
                return _ticketDAO.GetTicketByCustomerUserName(customerUserName);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Get flight by flight ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Flight GetFlightByFlightId(LoginToken<Customer> token, long flightId)
        {
            if (token != null)
            {
                return _flightDAO.Get(flightId);
            }
            else
                throw new Exception("Token can't be null");
        }
        /// <summary>
        /// Return ticket that customer had purchase by using given flight.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="flight"></param>
        /// <returns></returns>
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            if (token != null)
            {
                int value = DateTime.Compare(flight.DEPARTURE_TIME, DateTime.Now);
                if (_flightDAO.GetReminingTickets(flight.ID) <= 0 || value > 0)
                {
                    throw new NoTicketsException("There is not tickets");
                }
                else
                {
                    Ticket ticket = new Ticket()
                    {
                        FLIGHT_ID = flight.ID,
                        CUSTOMER_ID = token.User.ID
                    };
                    long ID = _ticketDAO.Add(ticket);
                    ticket.ID = ID;
                    _flightDAO.UpdateRemainingTickets(flight.ID);

                    return ticket;
                }
            }
            else
                throw new Exception("Token can't be null");
        }
        public Ticket GetTicketByTicketId(LoginToken<Customer> token, long ticketId)
        {
            if (token != null)
            {
                return _ticketDAO.Get(ticketId);
            }
            else
                throw new Exception("Token can't be null");
        }


    }
}
