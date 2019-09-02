using System;
using System.Collections.Generic;
using System.IO;
using AirlineManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirlineUnitTest
{
    [TestClass]
    public class A_AdministratorFacadeTest
    {
        Country newCountry1 = null;
        Country newCountry2 = null;
        AirlineCompany newAirlineCompany = null;
        Customer newCustomer = null;
        private static void AddToLogFile(string str)
        {
            DateTime dt = DateTime.Now;
            string ll = dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString();
            string path = @"C:\Log\myUnitTestLog.txt";
            
            TextWriter writer = new StreamWriter(path, true);
            writer.WriteLine(ll +" "+ str);
            writer.Close();
        }
        [ClassInitialize()]
        public static void InitAdminTest(TestContext testContext)
        {
            AddToLogFile("run init db");
            InitDBUnitTest.InitDB();
        }
        public ILoggedInAdministratorFacade GetAdministratorFacade(out LoginToken<Administrator> t)
        {
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            ILoginToken loginToken = FCS.Login(TestResource.Administrator_USER_NAME, TestResource.Administrator_PASSWORD);
            t = loginToken as LoginToken<Administrator>;
            ILoggedInAdministratorFacade administratorFacade = FCS.GetFacade(loginToken) as ILoggedInAdministratorFacade;
            return administratorFacade;
        }
        public Customer CreateNewCustomer()
        {
            Customer newCustomer = new Customer
            {
                FIRST_NAME = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_FIRST_NAME,
                LAST_NAME = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_LAST_NAME,
                USER_NAME = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_USER_NAME,
                PASSWORD = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_PASSWORD,
                ADDRESS = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_ADDRESS,
                PHONE_NO = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.AdministratorFacade_CreateNewCustomer_AddCustomer_CREDIT_CARD_NUMBER
            };
            return newCustomer;
        }
        public AirlineCompany CreateNewAirlineCompany()
        {
            AirlineCompany newAirlineCompany = new AirlineCompany()
            {
                AIRLINE_NAME = TestResource.AdministratorFacade_CreateNewAirline1_AddAirlineCompany_AIRLINE_NAME,
                USER_NAME = TestResource.AdministratorFacade_CreateNewAirline1_AddAirlineCompany_USER_NAME,
                PASSWORD = TestResource.AdministratorFacade_CreateNewAirline1_AddAirlineCompany_PASSWORD,
            };
            return newAirlineCompany;
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
        [TestMethod]
        public void AdministratorFacade_RemoveCountry_CountryRemoved()
        {
            AddToLogFile("Run RemoveCountry");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCountry1 = CreateNewCountry1();
            Country c = administratorFacade.GetCountryByName(t, newCountry1.COUNTRY_NAME);
            if (c != null)
            {
                administratorFacade.RemoveCountry(t, c);
            }
            else
            {
                long countryCode = administratorFacade.CreateNewCountry(t, newCountry1);
                newCountry1.ID = countryCode;
                c = newCountry1;
                administratorFacade.RemoveCountry(t, c);
            }
            Country createdCountry = administratorFacade.GetCountryByCode(t, c.ID);
            Assert.AreEqual(null, createdCountry);

        }
        [TestMethod]
        public void AdministratorFacade_CreateNewCountry_AddCountry()
        {
            AddToLogFile("Run CreateNewCountry");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCountry1 = CreateNewCountry1();
            long countryCode1 = administratorFacade.CreateNewCountry(t, newCountry1);
            newCountry1.ID = countryCode1;
            Country c1 = administratorFacade.GetCountryByCode(t, countryCode1);

            newCountry2 = CreateNewCountry2();
            long countryCode2 = administratorFacade.CreateNewCountry(t, newCountry2);
            newCountry2.ID = countryCode2;
            Country c2 = administratorFacade.GetCountryByCode(t, countryCode2);

            Assert.AreEqual(c1, newCountry1);
            Assert.AreEqual(c2, newCountry2);
        }
        [TestMethod]
        public void AdministratorFacade_RemoveAirline_AirlineRemoved()
        {
            AddToLogFile("Run RemoveAirline");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newAirlineCompany = CreateNewAirlineCompany();
            AirlineCompany a = administratorFacade.GetAirlineCompanyByAirlineName(t, newAirlineCompany.AIRLINE_NAME);
            if (a != null)
            {
                administratorFacade.RemoveAirline(t, a);
            }
            else
            {
                newCountry1 = CreateNewCountry1();
                Country c = administratorFacade.GetCountryByName(t, newCountry1.COUNTRY_NAME);
                long countryCode = 0;
                if (c == null)
                {
                    countryCode = administratorFacade.CreateNewCountry(t, newCountry1);
                    newCountry1.ID = countryCode;
                    c = newCountry1;
                }
                newAirlineCompany.COUNTRY_CODE = c.ID;
                long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
                newAirlineCompany.ID = ID;
                a = newAirlineCompany;
                administratorFacade.RemoveAirline(t, a);
            }
            AirlineCompany createdAirlineCompany = administratorFacade.GetAirlineCompanyById(t, a.ID);
            Assert.AreEqual(null, createdAirlineCompany);
        }
       
        [TestMethod]
        public void AdministratorFacade_CreateNewCustomer_AddCustomer()
        {
            AddToLogFile("Run CreateNewCustome");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCustomer = CreateNewCustomer();
            Customer c = administratorFacade.GetCustomerByUserName(t, newCustomer.USER_NAME);
            if (c != null)
            {
                administratorFacade.RemoveCustomer(t, c);
            }
            long ID = administratorFacade.CreateNewCustomer(t, newCustomer);
            newCustomer.ID = ID;
            c = administratorFacade.GetCustomerById(t, ID);
            Assert.AreEqual(c, newCustomer);
        }
        [TestMethod]
        public void AdministratorFacade_CreateNewAirline_AddAirlineCompany()
        {
            AddToLogFile("Run CreateNewAirline");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCountry1 = CreateNewCountry1();
            Country c = administratorFacade.GetCountryByName(t, newCountry1.COUNTRY_NAME);
            long countryCode = 0;
            if (c == null)
            {
                countryCode = administratorFacade.CreateNewCountry(t, newCountry1);
                newCountry1.ID = countryCode;
                c = newCountry1;
            }
            newAirlineCompany = CreateNewAirlineCompany();
            AirlineCompany a = administratorFacade.GetAirlineCompanyByAirlineName(t, newAirlineCompany.AIRLINE_NAME);
            if (a != null)
            {
                administratorFacade.RemoveAirline(t, a);
            }
            newAirlineCompany.COUNTRY_CODE = c.ID;
            long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
            newAirlineCompany.ID = ID;
            AirlineCompany createdAirlineCompany = administratorFacade.GetAirlineCompanyById(t, newAirlineCompany.ID);
            Assert.AreEqual(createdAirlineCompany, newAirlineCompany);
        }
    
        [TestMethod]
        public void AdministratorFacade_RemoveCustomer_CustomerRemoved()
        {
            AddToLogFile("Run RemoveCustomer");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCustomer = CreateNewCustomer();
            Customer c = administratorFacade.GetCustomerByUserName(t, newCustomer.USER_NAME);
            if (c != null)
            {
                administratorFacade.RemoveCustomer(t, c);
            }
            else
            {
                long ID = administratorFacade.CreateNewCustomer(t, newCustomer);
                newCustomer.ID = ID;
                c = administratorFacade.GetCustomerById(t, newCustomer.ID);
                administratorFacade.RemoveCustomer(t, c);
            }
            Customer createdCustomer = administratorFacade.GetCustomerById(t, c.ID);
            Assert.AreEqual(null, createdCustomer);
        }
        
        [TestMethod]
        public void AdministratorFacade_UpdateCustomerDetail_CustomerUpdated()
        {
            AddToLogFile("Run UpdateCustomerDetail");
            Customer uc = null;
            Customer updatedCustomer = new Customer
            {
                FIRST_NAME = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_FIRST_NAME,
                LAST_NAME = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_LAST_NAME,
                USER_NAME = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_USER_NAME,
                PASSWORD = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_PASSWORD,
                ADDRESS = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_ADDRESS,
                PHONE_NO = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_PHONE_NO,
                CREDIT_CARD_NUMBER = TestResource.AdministratorFacade_UpdateCustomerDetail_CustomerUpdated_CREDIT_CARD_NUMBER
            };
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newCustomer = CreateNewCustomer();
            Customer c = administratorFacade.GetCustomerByUserName(t, newCustomer.USER_NAME);
            if (c == null)
            {
                long ID = administratorFacade.CreateNewCustomer(t, CreateNewCustomer());
                updatedCustomer.ID = ID;
                administratorFacade.UpdateCustomerDetails(t, updatedCustomer);
            }
            else
            {
                updatedCustomer.ID = c.ID;
            }
            uc = administratorFacade.GetCustomerById(t, updatedCustomer.ID);
            Assert.AreEqual(updatedCustomer, uc);
        }
        [TestMethod]
        public void AdministratorFacade_UpdateAirlineDetail_AirlineCompanyUpdated()
        {
            AddToLogFile("Run UpdateAirlineDetail");
            AirlineCompany ua = null;
            AirlineCompany updatedAirlineCompany = new AirlineCompany
            {
                AIRLINE_NAME = TestResource.AdministratorFacade_UpdateAirlineDetail_AirlineCompanyUpdated_AIRLINE_NAME,
                USER_NAME = TestResource.AdministratorFacade_UpdateAirlineDetail_AirlineCompanyUpdated_USER_NAME,
                PASSWORD = TestResource.AdministratorFacade_UpdateAirlineDetail_AirlineCompanyUpdated_PASSWORD,
            };
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            newAirlineCompany = CreateNewAirlineCompany();
            AirlineCompany a = administratorFacade.GetAirlineCompanyByAirlineName(t, newAirlineCompany.AIRLINE_NAME);
            if (a != null)
            {
                updatedAirlineCompany.ID = a.ID;
                updatedAirlineCompany.COUNTRY_CODE = a.COUNTRY_CODE;
                administratorFacade.UpdateAirlineDetails(t, updatedAirlineCompany);
            }
            else
            {
                newCountry1 = CreateNewCountry1();
                Country c = administratorFacade.GetCountryByName(t, newCountry1.COUNTRY_NAME);
                long countryCode = 0;
                if (c == null)
                {
                    countryCode = administratorFacade.CreateNewCountry(t, newCountry1);
                    newCountry1.ID = countryCode;
                    c = newCountry1;
                }
                newAirlineCompany.COUNTRY_CODE = c.ID;
                long ID = administratorFacade.CreateNewAirline(t, newAirlineCompany);
  
                updatedAirlineCompany.ID = ID;
                updatedAirlineCompany.COUNTRY_CODE = newAirlineCompany.COUNTRY_CODE;
                administratorFacade.UpdateAirlineDetails(t, updatedAirlineCompany);
            }
            ua = administratorFacade.GetAirlineCompanyById(t, updatedAirlineCompany.ID);
            Assert.AreEqual(updatedAirlineCompany, ua);
        }
        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void AdministratorWrongPassword()
        {
            AddToLogFile("Run AdministratorWrongPassword");
            FlyingCenterSystem FCS = FlyingCenterSystem.GetFlyingCenterSystemInstance();
            FCS.Login(TestResource.Administrator_USER_NAME, TestResource.Administrator_AdministratorPasswordNotFound_PASSWORD);
        }
        [TestMethod]
        [ExpectedException(typeof(AirlineCompanyAlreadyExistException))]
        public void AirlineCompanyAlreadyExist()
        {
            AddToLogFile("Run AdministratorWrongPassword");
         
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            Country newCountry1 = CreateNewCountry1();
            long countryCode = administratorFacade.GetCountryByName(t, newCountry1.COUNTRY_NAME).ID;
            AirlineCompany newAirlineCompany = CreateNewAirlineCompany();
            newAirlineCompany.COUNTRY_CODE = countryCode;
            administratorFacade.CreateNewAirline(t, newAirlineCompany);
            administratorFacade.CreateNewAirline(t, newAirlineCompany);
        }
        [TestMethod]
        [ExpectedException(typeof(CustomerAlreadyExistException))]
        public void CustomerAlreadyExist()
        {
            AddToLogFile("Run CustomerAlreadyExist");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            administratorFacade.CreateNewCustomer(t, CreateNewCustomer());
            administratorFacade.CreateNewCustomer(t, CreateNewCustomer());
        }
        [TestMethod]
        [ExpectedException(typeof(CountryAlreadyExistException))]
        public void CountryAlreadyExist()
        {
            AddToLogFile("Run  CountryAlreadyExist");
            ILoggedInAdministratorFacade administratorFacade = GetAdministratorFacade(out LoginToken<Administrator> t);
            administratorFacade.CreateNewCountry(t, CreateNewCountry1());
            administratorFacade.CreateNewCountry(t, CreateNewCountry1());
        }
    }
}
