using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagement
{
    public class CountryDAOMSSQL : ICountryDAO
    {
        private SqlDAO DL;  // A central class of database connections
        public CountryDAOMSSQL()
        {
            DL = new SqlDAO(FlightCenterConfig.strConn);
        }
        public long Add(Country t)
        {
                StringBuilder sb = new StringBuilder();
                string SQL1 = $"SELECT COUNT(*) FROM Countries WHERE COUNTRY_NAME = '{t.COUNTRY_NAME}'";
                string res = DL.ExecuteSqlScalarStatement(SQL1);
                if (res == "0")
                {
                    sb = new StringBuilder();
                    sb.Append($"INSERT INTO Countries(COUNTRY_NAME)");
                    sb.Append($" values('{ t.COUNTRY_NAME}')");
                    string SQL = sb.ToString();
                    DL.ExecuteSqlNonQuery(SQL);
                    SQL = $"SELECT ID FROM Countries WHERE COUNTRY_NAME ='{t.COUNTRY_NAME}'";

                    return Int64.Parse(DL.ExecuteSqlScalarStatement(SQL));
                }
                else
                {
                    throw new CountryAlreadyExistException("Country already exists");
                }
        }
        public Country Get(long id)
        {
            Country country = null;
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT * FROM Countries WHERE ID = {id}");
            string SQL = sb.ToString();
            DataSet DS = DL.GetSqlQueryDS(SQL, "Countries");
            DataTable dt = DS.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                country = new Country();
                country.ID = Convert.ToInt64(dr["ID"]);
                country.COUNTRY_NAME = (string)dr["COUNTRY_NAME"];
            }
            if (country != null)
            {
                return country;
            }
            return null;
        }
        public Country GetCountryByName(string countryName)
        {
            Country country = null;
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT * FROM Countries WHERE COUNTRY_NAME = '{countryName}'");
            string SQL = sb.ToString();
            DataSet DS = DL.GetSqlQueryDS(SQL, "Countries");
            DataTable dt = DS.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                country = new Country();
                country.ID = Convert.ToInt64(dr["ID"]);
                country.COUNTRY_NAME = (string)dr["COUNTRY_NAME"];
            }
            if (country != null)
            {
                return country;
            }
            return null;
        }

        public IList<Country> GetAll()
        {
            IList<Country> countries = new List<Country>();
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT * FROM Countries");
            string SQL = sb.ToString();
            DataSet DS = DL.GetSqlQueryDS(SQL, "Countries");
            DataTable dt = DS.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Country country = new Country();
                country.ID = (long)dr["ID"];
                country.COUNTRY_NAME = (string)dr["COUNTRY_NAME"];
                countries.Add(country);
            }
            return countries;
        }

        public void Remove(Country t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"DELETE FROM Countries WHERE ID = {t.ID}");
            string SQL = sb.ToString();
            string res = DL.ExecuteSqlNonQuery(SQL);
            if (res == "")
            {
                throw new CountryDeleteErrorException("Country delete error");
            }
        }

        public void Update(Country t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"UPDATE Countries SET COUNTRY_NAME = '{t.COUNTRY_NAME}'");
            sb.Append($" WHERE ID = {t.ID}");
            string SQL = sb.ToString();
            string res = DL.ExecuteSqlNonQuery(SQL);
            if (res == "")
            {
                throw new CountryUpdateErrorException("Country update error");
            }
        }
    }
}
