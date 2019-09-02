using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlineManagement;
using System.Collections.Generic;
using System.IO;

namespace AirlineUnitTest
{
    [TestClass]
    public class B_CustomerFacadeTest
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
        public ILoggedInCustomerFacade GetCustomerFacade(out LoginToken<Customer> tCustomer)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.CustomerFacade_Customer_USER_NAME, TestResource.CustomerFacade_Customer_PASSWORD);
            tCustomer = loginToken as LoginToken<Customer>;
            ILoggedInCustomerFacade customerFacade = FCS.GetFacade(loginToken) as ILoggedInCustomerFacade;
            return customerFacade;
        }
        public ILoggedInAirlineFacade GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.CustomerFacade_AirlineCompany1_USER_NAME, TestResource.CustomerFacade_AirlineCompany1_PASSWORD);
            tAirlineCompany = loginToken as LoginToken<AirlineCompany>;
            ILoggedInAirlineFacade airlineCompanyFacade = FCS.GetFacade(loginToken) as ILoggedInAirlineFacade;
            return airlineCompanyFacade;
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
        public Customer CreateNewCustomer()
        {
            Customer newCustomer = new Customer
            {
                FIRST_NAME = TestResource.CustomerFacade_Customer_FIRST_NAME,
                LAST_NAME = TestResource.CustomerFacade_Customer_LAST_NAME,
                USER_NAME = TestResource.CustomerFacade_Customer_USER_NAME,
                PASSWORD = TestResource.CustomerFacade_Customer_PASSWORD,
                ADDRESS = TestResource.CustomerFacade_Customer_ADDRESS,
                PHONE_NO = TestResource.CustomerFacade_Customer_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.CustomerFacade_Customer_CREDIT_CARD_NUMBER
            };
            return newCustomer;
        }
        public Flight CreateNewFlight1()
        {
            Flight newFlight1 = new Flight
            {
                DEPARTURE_TIME = TestResource.CustomerFacade_CreateNewFlight_DEPARTURE_TIME,
                LANDING_TIME = TestResource.CustomerFacade_CreateNewFlight_LANDING_TIME,
                REMANING_TICKETS = TestResource.CustomerFacade_CreateNewFlight_REMANING_TICKETS,
                TOTAL_TICKETS = TestResource.CustomerFacade_CreateNewFlight_TOTAL_TICKETS
            };
            return newFlight1;
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
        public void CustomerFacade_AddTicket_TicketAdded()
        {
            AddToLogFile("run CustomerFacade AddTicket");
            InitDBUnitTest.InitDB();
            Ticket ticket1 = null;
            Ticket ticket2 = null;
            Customer customer = AdministratorFacade_CreateNewCustomer();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            ticket1 = customerFacade.PurchaseTicket(tCustomer, flight);
            ticket2 = customerFacade.GetTicketByCustomerUserName(tCustomer, customer.USER_NAME);
            Assert.AreEqual(ticket1, ticket2);
        }

        [TestMethod]
        public void CustomerFacade_GetAllFlights_FlightsReceived()
        {
            AddToLogFile("run CustomerFacade GetAllFlights");
            InitDBUnitTest.InitDB();
            IList<Flight> flights1 = null;
            IList<Flight> flights2 = null;
            AdministratorFacade_CreateNewCustomer();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            flights1 = customerFacade.GetAllFlights(tCustomer);
            flights2 = new List<Flight>();
            flights2.Add(flight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
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
        public void CustomerFacade_GetAllMyFlights_FlightsReceived()
        {
            AddToLogFile("run CustomerFacade GetAllMyFlights");
            InitDBUnitTest.InitDB();
            IList<Flight> flights1 = null;
            IList<Flight> flights2 = null;
            Customer customer = AdministratorFacade_CreateNewCustomer();
            CustomerFacade_CreateNewTicket();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            flights1 = customerFacade.GetAllMyFlights(tCustomer, customer.USER_NAME);
            Flight newFlight = CreateNewFlight1();
            newFlight.ID = flights1[0].ID;
            newFlight.AIRLINECOMPANY_ID = flights1[0].AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flights1[0].ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flights1[0].DESTINATION_COUNTRY_CODE;
            flights2 = new List<Flight>();
            flights2.Add(newFlight);
            Assert.AreNotEqual(null, flights1);
            List <Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            CollectionAssert.AreEqual(f1, f2);
            Assert.AreEqual(flights1[0].ID, flights2[0].ID);
            Assert.AreEqual(flights1[0].AIRLINECOMPANY_ID, flights2[0].AIRLINECOMPANY_ID);
            Assert.AreEqual(flights1[0].ORIGIN_COUNTRY_CODE, flights2[0].ORIGIN_COUNTRY_CODE);
            Assert.AreEqual(flights1[0].DESTINATION_COUNTRY_CODE, flights2[0].DESTINATION_COUNTRY_CODE);
            Assert.AreEqual(flights1[0].DEPARTURE_TIME, flights2[0].DEPARTURE_TIME);
            Assert.AreEqual(flights1[0].LANDING_TIME, flights2[0].LANDING_TIME);
            Assert.AreEqual(flights1[0].REMANING_TICKETS, flights2[0].REMANING_TICKETS-1);
            Assert.AreEqual(flights1[0].TOTAL_TICKETS, flights2[0].TOTAL_TICKETS);
        }

        [TestMethod]
        [ExpectedException(typeof(TicketAlreadyExistException))]
        public void TicketAlreadyExist()
        {
            AddToLogFile("run CustomerFacade TicketAlreadyExist Exception");
            InitDBUnitTest.InitDB();
            AdministratorFacade_CreateNewCustomer();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            customerFacade.PurchaseTicket(tCustomer, flight);
            customerFacade.PurchaseTicket(tCustomer, flight);
        }

        [TestMethod]
        [ExpectedException(typeof(NoTicketsException))]
        public void NoTicketLeft()
        {
            AddToLogFile("run CustomerFacade NoTicketLeft Exception");
            InitDBUnitTest.InitDB();
            Flight newFlight1 = null;
            AdministratorFacade_CreateNewCustomer();
            Flight flight1 = AirlineCompanyFacadeFacade_CreateNewFlight1();
            ILoggedInCustomerFacade customerFacade = GetCustomerFacade(out LoginToken<Customer> tCustomer);
            ILoggedInAirlineFacade airlineCompanyFacade = GetAirlineCompanyFacade(out LoginToken<AirlineCompany> tAirlineCompany);
            newFlight1 = CreateNewFlight1();
            newFlight1.ID = flight1.ID;
            newFlight1.AIRLINECOMPANY_ID = flight1.AIRLINECOMPANY_ID;
            newFlight1.ORIGIN_COUNTRY_CODE = flight1.ORIGIN_COUNTRY_CODE;
            newFlight1.DESTINATION_COUNTRY_CODE = flight1.DESTINATION_COUNTRY_CODE;
            newFlight1.REMANING_TICKETS = 0;
            airlineCompanyFacade.UpdateRemainingTickets(tAirlineCompany, newFlight1);
            Flight flight2 = customerFacade.GetFlightByFlightId(tCustomer, newFlight1.ID);
            customerFacade.PurchaseTicket(tCustomer, flight2);
        }
        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void CustomerWrongPassword()
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.CustomerFacade_Customer_USER_NAME, TestResource.CustomerFacade_CustomerWrongPassword_PASSWORD);
        }
    }

}
