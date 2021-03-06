﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class SiteSqlDAO : ISiteSqlDAO
    {
        private string connectionString;


        public SiteSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public IList<Site> SearchSitesByDate(int campgroundID, DateTime fromDate, DateTime toDate)
        {

            List<Site> sites = new List<Site>();
            string sqlQuery = @"Select Top 5 site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities from site 
                                    where campground_id = @campground_id and site_id not in
                                        (Select s.site_id from site s
                                        join reservation r on s.site_id = r.site_id
                                        where campground_id = @campground_id AND ((from_date between @from AND @to) OR
                                        (to_date between @from AND @to) OR
                                        (from_date = @from AND to_date = @to) OR
                                        (from_date < @from AND to_date > @to) OR
                                        (to_date = @from) OR
                                        (from_date = @to)))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@campground_id", campgroundID);
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Site site = RowToObject(rdr);
                        sites.Add(site);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return sites;
        }

        private static Site RowToObject(SqlDataReader rdr)
        {
            Site site = new Site();
            site.Site_ID = Convert.ToInt32(rdr["site_id"]);
            site.Campground_ID = Convert.ToInt32(rdr["campground_id"]);
            site.Site_Number = Convert.ToInt32(rdr["site_number"]);
            site.Max_Occupancy = Convert.ToInt32(rdr["max_occupancy"]);
            site.IsAccessible = Convert.ToBoolean(rdr["accessible"]);
            site.Max_RV_Length = Convert.ToInt32(rdr["max_rv_length"]);
            site.HasUtilities = Convert.ToBoolean(rdr["utilities"]);
            return site;
        }
    }
}
