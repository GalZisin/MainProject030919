using AirlineManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineUnitTest
{
    public static class InitDBUnitTest
    {
        public static void InitDB()
        {
            SqlDAO DL = new SqlDAO(FlightCenterConfig.strConn);
            string SQL = "DELETE FROM Tickets";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Customers";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Flights";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM AirlineCompanies";
            DL.ExecuteSqlNonQuery(SQL);
            SQL = "DELETE FROM Countries";
            DL.ExecuteSqlNonQuery(SQL);
        }
    }
}

