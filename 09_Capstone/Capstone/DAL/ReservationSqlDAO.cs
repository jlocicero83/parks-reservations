using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationSqlDAO
    {
        private string connectionString;

        public ReservationSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public int BookReservation(int site_id, string name, DateTime fromDate, DateTime toDate)
        {
            int confirmationNumber;
            string SqlQuery = @"insert into reservation (site_id, name, from_date, to_date)
	                                values (@site_id, @name, @from_date, @to_date)
                                    select reservation_id from reservation where name = @name and                                         
                                    from_date = @from_date and 
                                    to_date = @to_date";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                    cmd.Parameters.AddWithValue("@site_id", site_id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@from_date", fromDate);
                    cmd.Parameters.AddWithValue("@to_date", toDate);

                    confirmationNumber = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (SqlException ex)
            {
                throw;
            }
            return confirmationNumber;
        }

        public decimal GetTotalCost(int campground_id, DateTime from_date, DateTime to_date)
        {
            int durationOfStay = (to_date - from_date).Days;
            decimal totalCost;
            string sqlQuery = @"select daily_fee from campground
	                                where campground_id = @campground_id";

            try
            {
                decimal dailyFee;
               using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@campground_id", campground_id);
                    dailyFee = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                totalCost = dailyFee * durationOfStay;
                return totalCost;
            }
            catch (SqlException ex)
            {
                throw;
            }



        }
    }
}
