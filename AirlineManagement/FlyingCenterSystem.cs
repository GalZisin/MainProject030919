using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineManagement
{
    public class FlyingCenterSystem
    {
        private SqlDAO DL;
        private static FlyingCenterSystem _MyFlyingCenterInstance;
        private static object key = new object();
        int time = 20; // Constant time for transference 20:00
        protected FlyingCenterSystem()
        {
            DL = new SqlDAO(FlightCenterConfig.strConn);
          
            new Task(() =>
            {
                bool flag = true;
                while (true)
                {
                    if (DateTime.Now.Hour < time) // Checks every 10 minutes if the time for transference has passed or not
                    {
                        flag = true;
                    }
                    else
                    {
                        if (flag)
                        {
                            MoveTicketsExpired3HoursAgo();
                            MoveFlightsExpired3HoursAgo();
                        }
                        flag = false;
                    }
                    Thread.Sleep(600000); //10 minutes interval
                }
            });
        }
        public static FlyingCenterSystem GetFlyingCenterSystemInstance()
        {
            if (_MyFlyingCenterInstance == null)
            {
                lock (key)
                {
                    if (_MyFlyingCenterInstance == null)
                    {
                        _MyFlyingCenterInstance = new FlyingCenterSystem();
                    }
                }
            }
            return _MyFlyingCenterInstance;
        }

        public ILoginToken Login(string userName, string Password)
        {
            LoginService loginService = new LoginService();

            if (loginService.TryAdminLogin(userName, Password, out LoginToken<Administrator> AdminToken))
            {
                return AdminToken;
            }
            else if (loginService.TryAirlineLogin(userName, Password, out LoginToken<AirlineCompany> AirlineCompanyToken))
            {
                return AirlineCompanyToken;
            }
            else if (loginService.TryCustomerLogin(userName, Password, out LoginToken<Customer> CustomerToken))
            {
                return CustomerToken;
            }
            else
            return null;
        }

        public IFacade GetFacade(ILoginToken loginToken)
        {
            string a = "";
            if (loginToken != null)
            {
                a = loginToken.GetType().GenericTypeArguments[0].Name;
            }
            if (a == "Administrator")
            {
                return new LoggedInAdministratorFacade();
            }
            else if (a == "AirlineCompany")
            {
                return new LoggedInAirlineFacade();
            }
            else if (a == "Customer")
            {
                return new LoggedInCustomerFacade();
            }
            else // IloginToken is null - > user is Anonymous
                return new AnonymousUserFacade();
        }
        private void MoveTicketsExpired3HoursAgo()
        {
            //DateTime Time3HoursAgo = DateTime.Now.Subtract(DateTime.Now.AddHours(3) - DateTime.Now);
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO FlightsHistory SELECT *");
            sb.Append($"FROM Flights WHERE LANDING_TIME < DATEADD(hour, -3, SYSUTCDATETIME())");
            sb.Append($"AND Flights.ID NOT IN (SELECT ID FROM FlightsHistory)");
            string SQL = sb.ToString();
            DL.ExecuteSqlNonQuery(SQL);
            SQL = $"DELETE FROM Flights WHERE LANDING_TIME < DATEADD(hour, -3, SYSUTCDATETIME())";
            DL.ExecuteSqlNonQuery(SQL);
        }
        private void MoveFlightsExpired3HoursAgo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO TicketHistory SELECT * FROM Tickets ");
            sb.Append($"WHERE FLIGHT_ID IN (SELECT ID FROM Flights WHERE LANDING_TIME < DATEADD(hour, -3, SYSUTCDATETIME()))");
            sb.Append($"AND Tickets.ID NOT IN (SELECT ID FROM TicketHistory)");
            string SQL = sb.ToString();
            DL.ExecuteSqlNonQuery(SQL);
            SQL = $"DELETE FROM Tickets WHERE FLIGHT_ID IN (SELECT ID FROM Flights WHERE LANDING_TIME < DATEADD(hour, -3, SYSUTCDATETIME()))";
            DL.ExecuteSqlNonQuery(SQL);
        }

    }
}
