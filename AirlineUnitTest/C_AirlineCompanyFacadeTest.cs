using System;
using System.Collections.Generic;
using System.IO;
using AirlineManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTest
{
    [TestClass]
    public class C_AirlineCompanyFacadeTest
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
        public ILoggedInAirlineFacade GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.AirlineCompanyFacade_USER_NAME, TestResource.AirlineCompanyFacade_PASSWORD);
            tAirlineCompany = loginToken as LoginToken<AirlineCompany>;
            ILoggedInAirlineFacade airlineCompanyFacade = FCS.GetFacade(loginToken) as ILoggedInAirlineFacade;
            return airlineCompanyFacade;
        }
        public ILoggedInCustomerFacade GetCustomerFacade(out LoginToken<Customer> tCustomer)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.AirlineCompanyFacade_Customer1_USER_NAME, TestResource.AirlineCompanyFacade_Customer1_PASSWORD);
            tCustomer = loginToken as LoginToken<Customer>;
            ILoggedInCustomerFacade customerFacade = FCS.GetFacade(loginToken) as ILoggedInCustomerFacade;
            return customerFacade;
        }
        public ILoggedInAdministratorFacade GetAdministratorFacade(out LoginToken<Administrator> tAdministrator)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.Administrator_USER_NAME, TestResource.Administrator_PASSWORD);
            tAdministrator = loginToken as LoginToken<Administrator>;
            ILoggedInAdministratorFacade administratorFacade = FCS.GetFacade(loginToken) as ILoggedInAdministratorFacade;
            return administratorFacade;
        }
        public Country CreateNewCountry1()
        {
            Country newCountry1 = new Country()
            {
                COUNTRY_NAME = TestResource.AdministratorFacade_CreateNewCountry_AddCountry_COUNTRY_NAME1
            };
            return newCountry1;
        }
        public Country CreateNewCountry2()
        {
            Country newCountry2 = new Country()
            {
                COUNTRY_NAME = TestResource.AdministratorFacade_CreateNewCountry_AddCountry_COUNTRY_NAME2
            };
            return newCountry2;
        }
        public AirlineCompany CreateNewAirlineCompany1()
        {
            AirlineCompany newAirlineCompany1 = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.CustomerFacade_AirlineCompany1_AIRLINE_NAME,
                USER_NAME = TestResource.CustomerFacade_AirlineCompany1_USER_NAME,
                PASSWORD = TestResource.CustomerFacade_AirlineCompany1_PASSWORD,
            };
            return newAirlineCompany1;
        }
        public AirlineCompany CreateNewAirlineCompany2()
        {
            AirlineCompany newAirlineCompany2 = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.CustomerFacade_AirlineCompany2_AIRLINE_NAME,
                USER_NAME = TestResource.CustomerFacade_AirlineCompany2_USER_NAME,
                PASSWORD = TestResource.CustomerFacade_AirlineCompany2_PASSWORD,
            };
            return newAirlineCompany2;
        }
        public Flight CreateNewFlight1()
        {
            Flight newFlight1 = new Flight
            {
                DEPARTURE_TIME = TestResource.AirlineCompanyFacade_CreateNewFlight_DEPARTURE_TIME,
                LANDING_TIME = TestResource.AirlineCompanyFacade_CreateNewFlight_LANDING_TIME,
                REMANING_TICKETS = TestResource.AirlineCompanyFacade_CreateNewFlight_REMANING_TICKETS,
                TOTAL_TICKETS = TestResource.AirlineCompanyFacade_CreateNewFlight_TOTAL_TICKETS
            };
            return newFlight1;
        }
        public Customer CreateNewCustomer()
        {
            Customer newCustomer = new Customer()
            {
                FIRST_NAME = TestResource.AirlineCompanyFacade_Customer1_FIRST_NAME,
                LAST_NAME = TestResource.AirlineCompanyFacade_Customer1_LAST_NAME,
                USER_NAME = TestResource.AirlineCompanyFacade_Customer1_USER_NAME,
                PASSWORD = TestResource.AirlineCompanyFacade_Customer1_PASSWORD,
                ADDRESS = TestResource.AirlineCompanyFacade_Customer1_ADDRESS,
                PHONE_NO = TestResource.AirlineCompanyFacade_Customer1_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.AirlineCompanyFacade_Customer1_CREDIT_CARD_NUMBER
            };
            return newCustomer;
        }
        public AirlineCompany CreateNewAirlineCompany()
        {
            AirlineCompany newAirlineCompany = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.AirlineCompanyFacade_AIRLINE_NAME,
                USER_NAME = TestResource.AirlineCompanyFacade_USER_NAME,
                PASSWORD = TestResource.AirlineCompanyFacade_PASSWORD
            };
            return newAirlineCompany;
        }
        public Ticket CreateNewTicket()
        {
            Ticket newTicket = new Ticket();
            return newTicket;
        }
        public Country AdministratorFacade_CreateNewCountry1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newCountry1 = CreateNewCountry1();
            long countryCode1 = administratorFacade.CreateNewCountry(t, newCountry1);
            newCountry1.ID = countryCode1;
            return newCountry1;
        }
        public Country AdministratorFacade_CreateNewCountry2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newCountry2 = CreateNewCountry2();
            long countryCode2 = administratorFacade.CreateNewCountry(t, newCountry2);
            newCountry2.ID = countryCode2;
            return newCountry2;
        }
        public Customer AdministratorFacade_CreateNewCustomer()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Customer newCustomer = CreateNewCustomer();
            long ID = administratorFacade.CreateNewCustomer(t, newCustomer);
            newCustomer.ID = ID;
            return newCustomer;
        }
        public AirlineCompany AdministratorFacade_CreateNewAirline1()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country1 = AdministratorFacade_CreateNewCountry1();
            AirlineCompany newAirlineCompany = CreateNewAirlineCompany1();
            newAirlineCompany.COUNTRY_CODE = country1.ID;
            long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
            newAirlineCompany.ID = ID;
            return newAirlineCompany;
        }
        public AirlineCompany AdministratorFacade_CreateNewAirline2()
        {
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country country2 = AdministratorFacade_CreateNewCountry2();
            AirlineCompany newAirlineCompany = CreateNewAirlineCompany2();
            newAirlineCompany.COUNTRY_CODE = country2.ID;
            long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
            newAirlineCompany.ID = ID;
            return newAirlineCompany;
        }
        public Flight AirlineCompanyFacadeFacade_CreateNewFlight1()
        {
            Flight newFlight1 = null;
            AirlineCompany airlineCompany1 = AdministratorFacade_CreateNewAirline1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            newFlight1 = CreateNewFlight1();
            newFlight1.AIRLINECOMPANY_ID = airlineCompany1.ID;
            newFlight1.ORIGIN_COUNTRY_CODE = airlineCompany1.COUNTRY_CODE;
            Country country2 = AdministratorFacade_CreateNewCountry2();
            newFlight1.DESTINATION_COUNTRY_CODE = country2.ID;
            long ID = airlineCompanyFacade.CreateFlight(tAirlineCompany, newFlight1);
            newFlight1.ID = ID;
            return newFlight1;
        }
        public Ticket CustomerFacade_CreateNewTicket()
        {
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            Ticket ticket = customerFacade.PurchaseTicket(tCustomer, flight);
            return ticket;
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_CreateNewFlight_FlightAdded()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> t);
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            Flight f = airlineCompanyFacade.GetFlightByFlightId(t, newFlight.ID);
            Assert.AreNotEqual(null, f);
            Assert.AreEqual(newFlight, f);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_GetAllFlights_FlightsReceived()
        {
            IList<Flight> flights1 = null;
            IList<Flight> flights2 = null;
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            flights1 = airlineCompanyFacade.GetAllFlights(tAirlineCompany);
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            flights2 = new List<Flight>();
            flights2.Add(newFlight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            Assert.AreNotEqual(null, flights1);
            Assert.AreNotEqual(null, flights2);
            CollectionAssert.AreEqual(f1, f2);
            Assert.AreEqual(flights1[0].ID, flights2[0].ID);
            Assert.AreEqual(flights1[0].AIRLINECOMPANY_ID, flights2[0].AIRLINECOMPANY_ID);
            Assert.AreEqual(flights1[0].ORIGIN_COUNTRY_CODE, flights2[0].ORIGIN_COUNTRY_CODE);
            Assert.AreEqual(flights1[0].DESTINATION_COUNTRY_CODE, flights2[0].DESTINATION_COUNTRY_CODE);
            Assert.AreEqual(flights1[0].DEPARTURE_TIME, flights2[0].DEPARTURE_TIME);
            Assert.AreEqual(flights1[0].LANDING_TIME, flights2[0].LANDING_TIME);
            Assert.AreEqual(flights1[0].REMANING_TICKETS, flights2[0].REMANING_TICKETS);
            Assert.AreEqual(flights1[0].TOTAL_TICKETS, flights2[0].TOTAL_TICKETS);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_GetAllTickets_TicketsReceived()
        {
            Ticket newTicket = null;
            IList<Ticket> tickets1 = null;
            IList<Ticket> tickets2 = null;
            InitDBUnitTest.InitDB();
            AdministratorFacade_CreateNewCustomer();
            Flight flight1 = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            Ticket ticket = customerFacade.PurchaseTicket(tCustomer, flight1);
            tickets1 = airlineCompanyFacade.GetAllTickets(tAirlineCompany);
            newTicket = CreateNewTicket();
            newTicket.ID = ticket.ID;
            newTicket.FLIGHT_ID = ticket.FLIGHT_ID;
            newTicket.CUSTOMER_ID = ticket.CUSTOMER_ID;
            tickets2 = new List<Ticket>();
            tickets2.Add(newTicket);
            List<Ticket> t1 = (List<Ticket>)tickets1;
            List<Ticket> t2 = (List<Ticket>)tickets2;
            Assert.AreNotEqual(tickets1, null);
            Assert.AreNotEqual(tickets2, null);
            CollectionAssert.AreEqual(t1, t2);
            Assert.AreEqual(tickets1[0].ID, tickets2[0].ID);
            Assert.AreEqual(tickets1[0].FLIGHT_ID, tickets2[0].FLIGHT_ID);
            Assert.AreEqual(tickets1[0].CUSTOMER_ID, tickets2[0].CUSTOMER_ID);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_UpdateFlight_FlightUpdated()
        {
            Flight updatedFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight1 = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            updatedFlight = new Flight();
            updatedFlight.ID = flight1.ID;
            updatedFlight.AIRLINECOMPANY_ID = flight1.AIRLINECOMPANY_ID;
            updatedFlight.ORIGIN_COUNTRY_CODE = flight1.ORIGIN_COUNTRY_CODE;
            updatedFlight.DESTINATION_COUNTRY_CODE = flight1.DESTINATION_COUNTRY_CODE;
            updatedFlight.DEPARTURE_TIME = TestResource.AirlineCompanyFacade_UpdateFlightDetail_DEPARTURE_TIME;
            updatedFlight.LANDING_TIME = TestResource.AirlineCompanyFacade_UpdateFlightDetail_LANDING_TIME;
            updatedFlight.REMANING_TICKETS = TestResource.AirlineCompanyFacade_UpdateFlightDetail_REMANING_TICKETS;
            updatedFlight.TOTAL_TICKETS = TestResource.AirlineCompanyFacade_UpdateFlightDetail_TOTAL_TICKETS;
            airlineCompanyFacade.UpdateFlight(tAirlineCompany, updatedFlight);
            Flight f = airlineCompanyFacade.GetFlightByFlightId(tAirlineCompany, updatedFlight.ID);
            Assert.AreNotEqual(null, f);
            Assert.AreEqual(updatedFlight.ID, f.ID);
            Assert.AreEqual(updatedFlight.AIRLINECOMPANY_ID, f.AIRLINECOMPANY_ID);
            Assert.AreEqual(updatedFlight.ORIGIN_COUNTRY_CODE, f.ORIGIN_COUNTRY_CODE);
            Assert.AreEqual(updatedFlight.DESTINATION_COUNTRY_CODE, f.DESTINATION_COUNTRY_CODE);
            Assert.AreEqual(updatedFlight.LANDING_TIME, f.LANDING_TIME);
            Assert.AreEqual(updatedFlight.DEPARTURE_TIME, f.DEPARTURE_TIME);
            Assert.AreEqual(updatedFlight.REMANING_TICKETS, f.REMANING_TICKETS);
            Assert.AreEqual(updatedFlight.TOTAL_TICKETS, f.TOTAL_TICKETS);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_ModififyAirlineDetails_DetailsModified()
        {
            AirlineCompany newAirlineCompany = null;
            InitDBUnitTest.InitDB();
            AirlineCompany airlineCompany1 = AdministratorFacade_CreateNewAirline1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> tAdministrator);
            newAirlineCompany = CreateNewAirlineCompany();
            newAirlineCompany.ID = airlineCompany1.ID;
            newAirlineCompany.AIRLINE_NAME = TestResource.AirlineCompanyFacade_UpdatedName_AIRLINE_NAME;
            newAirlineCompany.COUNTRY_CODE = airlineCompany1.COUNTRY_CODE;
            airlineCompanyFacade.ModifyAirlineDetails(tAirlineCompany, newAirlineCompany);
            AirlineCompany airlineCompany2 = administratorFacade.GetAirlineCompanyById(tAdministrator, newAirlineCompany.ID);
            Assert.AreNotEqual(null, airlineCompany2);
            Assert.AreEqual(TestResource.AirlineCompanyFacade_UpdatedName_AIRLINE_NAME, airlineCompany2.AIRLINE_NAME);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_ChangeMyPassword_PasswordChanged()
        {
            InitDBUnitTest.InitDB();
            AirlineCompany airlineCompany1 = AdministratorFacade_CreateNewAirline1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> tAdministrator);
            airlineCompanyFacade.ChangeMyPassword(tAirlineCompany, tAirlineCompany.User.PASSWORD, TestResource.AirlineCompanyFacade_NewPassword_PASSWORD);
            AirlineCompany airlineCompany2 = administratorFacade.GetAirlineCompanyById(tAdministrator, airlineCompany1.ID);
            Assert.AreNotEqual(null, airlineCompany2);
            Assert.AreEqual(TestResource.AirlineCompanyFacade_NewPassword_PASSWORD, airlineCompany2.PASSWORD);
        }
        [TestMethod]
        public void AirlineCompanyFacadeFacade_CancelFlight_FlightCanceled()
        {
            InitDBUnitTest.InitDB();
            Flight flight1 = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);            
            airlineCompanyFacade.CancelFlight(tAirlineCompany, flight1);
            Flight flight2 = airlineCompanyFacade.GetFlightByFlightId(tAirlineCompany, flight1.ID);
            Assert.AreEqual(null, flight2);
        }
        [TestMethod]
        [ExpectedException(typeof(FlightAlreadyExistException))]
        public void FlightAlreadyExist()
        {
            InitDBUnitTest.InitDB();
            Flight flight1 = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            airlineCompanyFacade.CreateFlight(tAirlineCompany, flight1);
        }
        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void AirlineCompanyWrongPassword()
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.AirlineCompanyFacade_USER_NAME, TestResource.AirlineCompanyFacad_AirlineCompanyPasswordNotFound_PASSWORD);
        }
    }
}
