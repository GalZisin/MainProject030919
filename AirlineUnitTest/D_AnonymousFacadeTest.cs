using System;
using System.Collections.Generic;
using AirlineManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTest
{
    [TestClass]
    public class D_AnonymousFacadeTest
    {
        public AnonymousUserFacade GetAnonymousFacade()
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            AnonymousUserFacade anonymousFacade = FCS.GetFacade(null) as AnonymousUserFacade;
            return anonymousFacade;
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
        public Customer CreateNewCustomer()
        {
            Customer newCustomer = new Customer()
            {
                FIRST_NAME = TestResource.AnonymousFacade_Customer1_FIRST_NAME,
                LAST_NAME = TestResource.AnonymousFacade_Customer1_LAST_NAME,
                USER_NAME = TestResource.AnonymousFacade_Customer1_USER_NAME,
                PASSWORD = TestResource.AnonymousFacade_Customer1_PASSWORD,
                ADDRESS = TestResource.AnonymousFacade_Customer1_ADDRESS,
                PHONE_NO = TestResource.AnonymousFacade_Customer1_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.AnonymousFacade_Customer1_CREDIT_CARD_NUMBER
            };
            return newCustomer;
        }
        public Flight CreateNewFlight1()
        {
            Flight newFlight = new Flight
            {
                DEPARTURE_TIME = TestResource.AnonymousFacade_DEPARTURE_TIME,
                LANDING_TIME = TestResource.AnonymousFacade_LANDING_TIME,
                REMANING_TICKETS = TestResource.AnonymousFacade_REMANING_TICKETS,
                TOTAL_TICKETS = TestResource.AnonymousFacade_TOTAL_TICKETS
            };
            return newFlight;
        }
        public AirlineCompany CreateNewAirlineCompany1()
        {
            AirlineCompany newAirlineCompany1 = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.AnonymousFacade_CreateNewAirlineCompany1_AIRLINE_NAME,
                USER_NAME = TestResource.AnonymousFacade_CreateNewAirlineCompany1_USER_NAME,
                PASSWORD = TestResource.AnonymousFacade_CreateNewAirlineCompany1_PASSWORD,
            };
            return newAirlineCompany1;
        }
        public AirlineCompany CreateNewAirlineCompany2()
        {
            AirlineCompany newAirlineCompany2 = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.AnonymousFacade_CreateNewAirlineCompany2_AIRLINE_NAME,
                USER_NAME = TestResource.AnonymousFacade_CreateNewAirlineCompany2_USER_NAME,
                PASSWORD = TestResource.AnonymousFacade_CreateNewAirlineCompan2_PASSWORD,
            };
            return newAirlineCompany2;
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
        public void AnonymousFacade_GetFlightById_FlightFound()
        {
            Flight newFlight = null;
            Flight f = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            f = anonymousFacade.GetFlightById(newFlight.ID);
            Assert.AreNotEqual(f, null);
            Assert.AreEqual(f.ID, newFlight.ID);
            Assert.AreEqual(f.AIRLINECOMPANY_ID, newFlight.AIRLINECOMPANY_ID);
            Assert.AreEqual(f.ORIGIN_COUNTRY_CODE, newFlight.ORIGIN_COUNTRY_CODE);
            Assert.AreEqual(f.DESTINATION_COUNTRY_CODE, newFlight.DESTINATION_COUNTRY_CODE);
            Assert.AreEqual(f.DEPARTURE_TIME, newFlight.DEPARTURE_TIME);
            Assert.AreEqual(f.LANDING_TIME, newFlight.LANDING_TIME);
            Assert.AreEqual(f.REMANING_TICKETS, newFlight.REMANING_TICKETS);
            Assert.AreEqual(f.TOTAL_TICKETS, newFlight.TOTAL_TICKETS);
        }
        [TestMethod]
        public void AnonymousFacade_GetFlightsByDepatureDate_FlightsReceived()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            IList<Flight> flights1 = anonymousFacade.GetFlightsByDepatrureDate(newFlight.DEPARTURE_TIME);
            IList<Flight> flights2 = new List<Flight>();
            flights2.Add(newFlight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            Assert.AreNotEqual(flights1, null);
            Assert.AreNotEqual(flights2, null);
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
        public void AnonymousFacade_GetFlightsByDestinationCountry_FlightsReceived()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            IList<Flight> flights1 = anonymousFacade.GetFlightsByDestinationCountry(newFlight.DESTINATION_COUNTRY_CODE);
            IList<Flight> flights2 = new List<Flight>();
            flights2.Add(newFlight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            Assert.AreNotEqual(flights1, null);
            Assert.AreNotEqual(flights2, null);
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
        public void AnonymousFacade_GetFlighstByLandingDate_FlightsReceived()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            IList<Flight> flights1 = anonymousFacade.GetFlightsByLandingDate(newFlight.LANDING_TIME);
            IList<Flight> flights2 = new List<Flight>();
            flights2.Add(newFlight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            Assert.AreNotEqual(flights1, null);
            Assert.AreNotEqual(flights2, null);
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
        public void AnonymousFacade_GetFlighstByOriginCountry_FlightsReceived()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            IList<Flight> flights1 = anonymousFacade.GetFlightsByOriginCountry(newFlight.ORIGIN_COUNTRY_CODE);
            IList<Flight> flights2 = new List<Flight>();
            flights2.Add(newFlight);
            List<Flight> f1 = (List<Flight>)flights1;
            List<Flight> f2 = (List<Flight>)flights2;
            Assert.AreNotEqual(flights1, null);
            Assert.AreNotEqual(flights2, null);
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
        public void AnonymouseFacade_GetAllAirlineCompanies_AirlineCompaniesReceived()
        {
            InitDBUnitTest.InitDB();
            AirlineCompany airlineCompany1 = AdministratorFacade_CreateNewAirline1();
            AirlineCompany airlineCompany2 = AdministratorFacade_CreateNewAirline2();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            IList<AirlineCompany> airlineCompanies1 = anonymousFacade.GetAllAirlineCompanies();
            IList<AirlineCompany> airlineCompanies2 = new List<AirlineCompany>();
            airlineCompanies2.Add(airlineCompany1);
            airlineCompanies2.Add(airlineCompany2);
            List<AirlineCompany> a1 = (List<AirlineCompany>)airlineCompanies1;
            List<AirlineCompany> a2 = (List<AirlineCompany>)airlineCompanies2;
            CollectionAssert.AreEqual(a1, a2);
            Assert.AreEqual(airlineCompanies1[0].ID, airlineCompanies2[0].ID);
            Assert.AreEqual(airlineCompanies1[0].AIRLINE_NAME, airlineCompanies2[0].AIRLINE_NAME);
            Assert.AreEqual(airlineCompanies1[0].USER_NAME, airlineCompanies2[0].USER_NAME);
            Assert.AreEqual(airlineCompanies1[0].PASSWORD, airlineCompanies2[0].PASSWORD);
            Assert.AreEqual(airlineCompanies1[0].COUNTRY_CODE, airlineCompanies2[0].COUNTRY_CODE);
            Assert.AreEqual(airlineCompanies1[1].ID, airlineCompanies2[1].ID);
            Assert.AreEqual(airlineCompanies1[1].AIRLINE_NAME, airlineCompanies2[1].AIRLINE_NAME);
            Assert.AreEqual(airlineCompanies1[1].USER_NAME, airlineCompanies2[1].USER_NAME);
            Assert.AreEqual(airlineCompanies1[1].PASSWORD, airlineCompanies2[1].PASSWORD);
            Assert.AreEqual(airlineCompanies1[1].COUNTRY_CODE, airlineCompanies2[1].COUNTRY_CODE);
        }
        [TestMethod]
        public void AnonymouseFacade_GetAllFlights_FlightsReceived()
        {
            Flight newFlight = null;
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            IList<Flight> flights1 = anonymousFacade.GetAllFlights();
            newFlight = CreateNewFlight1();
            newFlight.ID = flight.ID;
            newFlight.AIRLINECOMPANY_ID = flight.AIRLINECOMPANY_ID;
            newFlight.ORIGIN_COUNTRY_CODE = flight.ORIGIN_COUNTRY_CODE;
            newFlight.DESTINATION_COUNTRY_CODE = flight.DESTINATION_COUNTRY_CODE;
            IList<Flight> flights2 = new List<Flight>();
            flights2.Add(newFlight);
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
        public void AnonymousFacade_GetAllFlightsByVacanvy_FlightsReceived()
        {
            InitDBUnitTest.InitDB();
            Flight flight = AirlineCompanyFacadeFacade_CreateNewFlight1();
            AnonymousUserFacade anonymousFacade = GetAnonymousFacade();
            Dictionary<Flight, int> FlightsByVacancy1 = new Dictionary<Flight, int>();
            FlightsByVacancy1.Add(flight, flight.REMANING_TICKETS);
            Dictionary<Flight, int>  FlightsByVacancy2 = anonymousFacade.GetAllFlightsByVacancy();
            Assert.AreNotEqual(FlightsByVacancy1, null);
            Assert.AreNotEqual(FlightsByVacancy2, null);
            CollectionAssert.AreEqual(FlightsByVacancy1, FlightsByVacancy2);
            Assert.AreEqual(FlightsByVacancy1[flight], FlightsByVacancy2[flight]);
        }
    }
}
