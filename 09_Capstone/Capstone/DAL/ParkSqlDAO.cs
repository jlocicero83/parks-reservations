using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    class ParkSqlDAO
    {
        private string connectionString;

        public ParkSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from park order by name", conn);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Park park = ConvertReaderToPark(rdr);
                        parks.Add(park);
                    }
                }
            }

            catch (SqlException)
            {
                throw;
            }

            return parks;

        }
        private static Park ConvertReaderToPark(SqlDataReader rdr)
        {
            Park park = new Park();
            park.Park_ID = Convert.ToInt32(rdr["park_id"]);
            park.Name = Convert.ToString(rdr["name"]);
            park.Location = Convert.ToString(rdr["location"]);
            park.Establish_Date = Convert.ToDateTime(rdr["establish_date"]);
            park.Area = Convert.ToInt32(rdr["area"]);
            park.Visitors = Convert.ToInt32(rdr["visitors"]);
            park.Description = Convert.ToString(rdr["description"]);

            return park;

        }

    }
}