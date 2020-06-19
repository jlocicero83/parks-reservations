using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundSqlDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }


        public IList<Campground> GetCampgroundsByParkID(int parkID)
        {
            List<Campground> campgrounds = new List<Campground>();
            string sqlQuery = "Select * from campground where park_id = @parkID";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@parkID", parkID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Campground campground = RowToObject(rdr);
                        campgrounds.Add(campground);

                    }
                }

            }
            catch (SqlException ex)
            {
                throw;
            }
            return campgrounds;
        }

        private static Campground RowToObject(SqlDataReader rdr)
        {
            Campground campground = new Campground();
            campground.Campgound_ID = Convert.ToInt32(rdr["campground_id"]);
            campground.Park_ID = Convert.ToInt32(rdr["park_id"]);
            campground.Name = Convert.ToString(rdr["name"]);
            campground.Open_From = Convert.ToInt32(rdr["open_from"]);
            campground.Open_To = Convert.ToInt32(rdr["open_to"]);
            campground.Daily_Fee = Convert.ToDecimal(rdr["daily_fee"]);

            return campground;
        }



    }
}
